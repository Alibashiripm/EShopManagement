using EShopManagement.Application.DTOs.User.Admin;
using EShopManagement.Application.Queries.Role;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.Role
{
    internal sealed class GetRoleUsersHandler : IQueryHandler<GetRoleUsers, List<AdminRoleUsersDto>>
    {
        private readonly DbSet<Domain.Entities.User.Role> _roles;


        public GetRoleUsersHandler(ReadDbContext context)
        {
            _roles = context.Roles;
        }
        public async Task<List<AdminRoleUsersDto>> HandleAsync(GetRoleUsers query)
        {
   return await _roles
         
                .Select(r => r.AsAdminRoleUsersDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
