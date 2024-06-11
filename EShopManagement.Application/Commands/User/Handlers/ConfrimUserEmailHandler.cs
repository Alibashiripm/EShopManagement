using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Services;

namespace EShopManagement.Application.Commands.User.Handlers
{
    internal sealed class ConfrimUserEmailHandler : ICommandHandler<ConfrimUserEmail, bool>
    {
 
         private readonly IUserService userService;

        public ConfrimUserEmailHandler( IUserService userService)
        {
      
             this.userService = userService;
        }
        public async Task<bool> HandleAsync(ConfrimUserEmail command)
        {
             var result = await userService.ConfrimEmailAsync(command.userName, command. activeCode);
             return result;
        }
    }
}
