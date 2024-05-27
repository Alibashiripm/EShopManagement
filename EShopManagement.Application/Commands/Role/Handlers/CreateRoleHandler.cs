using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Domain.Factories.User;
using EShopManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.Role.Handlers
{
    internal sealed class CreateRoleHandler : ICommandHandler<CreateRole>
    {
        private readonly IGenericRepository<Domain.Entities.User.Role, int> repository;
        private readonly IUserRoleFactory factory;

        public CreateRoleHandler(IGenericRepository<Domain.Entities.User.Role,int> repository,IUserRoleFactory factory)
        {
            this.repository = repository;
            this.factory = factory;
        }
        public async Task HandleAsync(CreateRole command)
        {
          var role =   factory.Create(command.Title);
          await repository.CreateAsync(role);
        }
    } 
}
