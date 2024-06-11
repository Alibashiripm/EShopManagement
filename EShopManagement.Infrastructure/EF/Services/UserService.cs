using EShopManagement.Application.Commands.Order;
using EShopManagement.Application.Commands.OrderDetail;
using EShopManagement.Application.DTOs.Order;
using EShopManagement.Application.DTOs.User.Authentication;
using EShopManagement.Application.Queries.User;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Entities.User;
using EShopManagement.Domain.Factories.User;
using EShopManagement.Domain.Repositories;
using EShopManagement.Domain.ValueObjects.User;
using EShopManagement.Infrastructure.EF.Contexts;

using EShopManagement.Infrastructure.EF.Queries;
using EShopManagement.Infrastructure.Exceptions;
using EShopManagement.Infrastructure.Services;
using EShopManagement.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using System.Security.Claims;
using ZarinpalSandbox;

namespace EShopManagement.Infrastructure.EF.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IServiceProvider _serviceProvider;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            _userManager = userManager;

            _signInManager = signInManager;
        }

        public Task<bool> CheckingCorrectnessOfOldPasswordAsync(User user, string oldPassword)
        {

            return _userManager.CheckPasswordAsync(user, oldPassword);
        }

        public async Task<bool> ConfrimEmailAsync(string userName, string activeCode)
        {
            User user = await _userManager.FindByNameAsync(userName) ?? throw new UserNotExistingExeption(userName);
            bool isCarrect = user.ActiveCode == activeCode ? true : false;
            if (isCarrect is false)
            {
                return isCarrect;
            }
            else
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var result = await _userManager.ConfirmEmailAsync(user, token);
                return true ? result.Succeeded : false;
            }
        }

        public async Task<SignInResult> LoginAsync(LoginUser query)
        {
            string info = query.UserNameOrEmail;
            var stringType = await UserServiceTool.ClassifyStringAsync(info);
            User user = new();
            try
            {
                switch (stringType)
                {
                    case StringType.UserName:
                        user = await _userManager.FindByNameAsync(info) ?? throw new UserNotExistingExeption(info);
                        break;
                    case StringType.Email:
                        user = await _userManager.FindByEmailAsync(info) ?? throw new UserNotExistingExeption(info); ;
                        break;
                }

            }
            catch (UserNotExistingExeption)
            {
                return SignInResult.Failed;
            }

            var result = await _signInManager.PasswordSignInAsync(user, query.Password, query.RememberMe, user.LockoutEnabled);
            if (result.Succeeded)
            {
                // Add custom claims
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim( "Email", user.Email),


            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await _signInManager.Context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            }
            if (user.EmailConfirmed == false && result.Succeeded)
            {
                return SignInResult.NotAllowed;
            }
            return result;
        }

        public async Task<bool> PremiumSubscriptionAsync(int orderId, int userId, IQueryCollection reuestQueries)
        {
            if (reuestQueries["Status"] != "" &&
                    reuestQueries["Status"].ToString().ToLower() == "ok"
                    && reuestQueries["Authority"] != "")
            {
                string authority = reuestQueries["Authority"];
                var user = await _userManager.FindByIdAsync(userId.ToString());
                //var payment = new Zarinpal.Payment(".", 30000);
                var payment = new Payment(30000);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    var paymentService = _serviceProvider.GetRequiredService<IOrderService>();
                    var context = _serviceProvider.GetRequiredService<WriteDbContext>();
                    var premiumFactory = _serviceProvider.GetRequiredService<IUserPremiumFactory>();

                    await paymentService.FinalizeOrderAsync(orderId, userId);
                    var rangeDate = new PremiumRangeDate(DateTime.Now, DateTime.Now.AddDays(30));
                    user.UserPremium = premiumFactory.Create(userId, rangeDate);
                    await context.UserPremiums.AddAsync(user.UserPremium);
                    await context.SaveChangesAsync();
                    return true; //Success
                }
            }
            return false;//Fail
        }

        public async Task<string> PremiumSubscriptionPaymentAsync(string email, int amount, string description, string callBackUrl, int orderId = 0)
        {
            var user = await _userManager.FindByEmailAsync(email);
            int userId = user.Id;
            var commandHandler = _serviceProvider.GetRequiredService<ICommandDispatcher>();
            var paymentService = _serviceProvider.GetRequiredService<IOrderService>();

            CreateOrder ordercommand = new CreateOrder(
                new OrderDto()
                {
                    CreateDate = DateTime.Now,
                    IsFinaly = false,
                    OrderSum = amount,
                    UserId = userId,
                    OrderDetails = new List<OrderDetailDto>() { new OrderDetailDto() { Price = amount } }
                });
            CreateOrderDetail createOrderDetail = new CreateOrderDetail(ordercommand.Order.OrderDetails.FirstOrDefault());
            orderId = await commandHandler.DispatchAsync<CreateOrder, int>(ordercommand);
            createOrderDetail.DetailDto.OrderId = orderId;
            await commandHandler.DispatchAsync(createOrderDetail);
            var result = await paymentService.HandleZarinpalPaymentAsync(email, amount, description, callBackUrl, orderId);
            if (result is not null)
            {
                return result;
            }
            return "0";
        }

        public async Task<IdentityResult> RegisterUserAsync(User user, string password)
        {

            var userByName = await _userManager.FindByNameAsync(user.UserName);
            var userByEmail = await _userManager.FindByEmailAsync(user.Email);


            if (userByName != null || userByEmail != null)
            {
                return IdentityResult.Failed(new IdentityError() { Code = 409.ToString(), Description = "There is a user with this name and email" });
            }
            user.EmailConfirmed = false;
            user.RegistrationDate = DateTime.Now;
            var emailSender = _serviceProvider.GetRequiredService<IEmailService>();
            var isRegisterSuccess = await _userManager.CreateAsync(user);
            string body = EmailServiceTools.GetConfirmEmailBody(user.ActiveCode, user.UserName);
            await emailSender.SendEmail(user.Email, "ConfirmEmail", body);
            return isRegisterSuccess.Succeeded ?
            await _userManager.AddPasswordAsync(user, password) :
            await Task.FromResult(IdentityResult.Failed());
        }

        public async Task UpdatePasswordAsync(User user, string oldPassword, string newPassword)
        {
            await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }
    }
}
