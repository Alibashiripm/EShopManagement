using EShopManagement.Application.DTOs.User.Authentication;
using EShopManagement.Application.Queries.User;
using EShopManagement.Application.Services;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Identity;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.User
{
    internal sealed class LoginUsertHandler : IQueryHandler<LoginUser, SignInResult>
    {
         private readonly IUserService userService;

        public LoginUsertHandler(IUserService userService)
        {
             this.userService = userService;
        }
        public async Task<SignInResult> HandleAsync(LoginUser query)
        {
             return await userService.LoginAsync(query);
        }
    }
}
