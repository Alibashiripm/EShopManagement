using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.Role.Handlers
{
    internal sealed class DeleteRoleHandler : ICommandHandler<DeleteRole>
    {
        private readonly IGenericRepository<Domain.Entities.User.Role, int> repository;

        public DeleteRoleHandler(IGenericRepository<Domain.Entities.User.Role,int> repository)
        {
            this.repository = repository;
        }
        public async Task HandleAsync(DeleteRole command)
        {
           await repository.DeleteAsync(command.Id);
        }
    }
}
