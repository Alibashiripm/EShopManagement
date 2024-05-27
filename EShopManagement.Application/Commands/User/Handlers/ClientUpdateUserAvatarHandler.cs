using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.User.Handlers
{
    internal sealed class ClientUpdateUserAvatarHandler : ICommandHandler<ClientUpdateUserAvatar>
    {

        private readonly IGenericRepository<Domain.Entities.User.User, int> repository;
        private readonly IUserService userService;

        public ClientUpdateUserAvatarHandler(IGenericRepository<Domain.Entities.User.User, int> repository, IUserService userService)
        {
            this.repository = repository;
            this.userService = userService;
        }
        public async Task HandleAsync(ClientUpdateUserAvatar command)
        {
            var user = await repository.GetByIdAsync(command.UserDto.UserId);
            user.UserAvatar = command.UserDto.UserAvatarName;
            await repository.UpdateAsync(user);
        }
    }
}
