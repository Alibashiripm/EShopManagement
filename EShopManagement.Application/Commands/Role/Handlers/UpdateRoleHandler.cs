using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.Role.Handlers
{
    internal sealed class UpdateRoleHandler : ICommandHandler<UpdateRole>
    {
        private readonly IGenericRepository<Domain.Entities.User.Role, int> repository;

        public UpdateRoleHandler(IGenericRepository<Domain.Entities.User.Role,int> repository)
        {
            this.repository = repository;
        }
        public async Task HandleAsync(UpdateRole command)
        {
            var role =await repository.GetByIdAsync(command.Id);
            role.Name = command.Title;
            await repository.UpdateAsync(role);
        }
    }
}
