using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Services;

namespace EShopManagement.Application.Commands.User.Handlers
{
    internal sealed class LoginUserHandler : ICommandHandler<LoginUser>
    {

        private readonly IUserService userService;

        public LoginUserHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task HandleAsync(LoginUser command)
        {
            await userService.LoginAsync(command.info,command.isPersistent, command.password);
        }
    }
}
