using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.User.Handlers
{
    internal sealed class ClientUpdateUserPasswordHandler : ICommandHandler<ClientUpdateUserPassword>
    {

        private readonly IGenericRepository<Domain.Entities.User.User, int> repository;
        private readonly IUserService userService;

        public ClientUpdateUserPasswordHandler(IGenericRepository<Domain.Entities.User.User, int> repository, IUserService userService)
        {

            this.repository = repository;
            this.userService = userService;
        }
        public async Task HandleAsync(ClientUpdateUserPassword command)
        {
            var user = await repository.GetByIdAsync(command.UserDto.UserId);
            var isOldPasswordCarreect = await userService.CheckingCorrectnessOfOldPasswordAsync(user, command.UserDto.OldPassword);
 
            if (isOldPasswordCarreect) 
            {
              await  userService.UpdatePasswordAsync(user, command.UserDto.OldPassword, command.UserDto.NewPassword);
            }
            await repository.UpdateAsync(user);
        }
    }
}
