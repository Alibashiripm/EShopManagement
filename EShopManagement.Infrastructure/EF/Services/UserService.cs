using EShopManagement.Application.Services;
using EShopManagement.Domain.Entities.User;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Infrastructure.Exceptions;
using EShopManagement.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;

namespace EShopManagement.Infrastructure.EF.Services
{
    internal sealed class UserService : IUserService

    {
        private readonly WriteDbContext _writeContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(WriteDbContext writeContext,
                           UserManager<User> userManager,
                           SignInManager<User> signInManager)


        {

            _writeContext = writeContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

   

        public Task<bool> CheckingCorrectnessOfOldPasswordAsync(User user, string oldPassword)
        {
            return _userManager.CheckPasswordAsync(user, oldPassword);
        }

        public async Task LoginAsync(string info, bool isPersistent, string password)
        {
            var stringType = await UserServiceTool.ClassifyStringAsync(info);
            User user = new();
            switch (stringType)
            {
                case StringType.UserName:
                    user = await _userManager.FindByNameAsync(info) ?? throw new UserNotExistingExeption(info);
                    break;
                case StringType.Email:
                    user = await _userManager.FindByEmailAsync(info) ?? throw new UserNotExistingExeption(info); ;
                    break;
            }
            bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, password);

            if (isPasswordCorrect)
            {
                await _signInManager.SignInAsync(user, isPersistent);
            }
        }

        public async Task RegisterUserAsync(User user, string password)
        {
            var isRegisterSuccess = await _userManager.CreateAsync(user);
            var result = isRegisterSuccess.Succeeded ?
            await _userManager.AddPasswordAsync(user, password) :
            await Task.FromResult(IdentityResult.Failed());
        }

        public async Task UpdatePasswordAsync(User user, string oldPassword, string newPassword)
        {
            await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }


    }
}
