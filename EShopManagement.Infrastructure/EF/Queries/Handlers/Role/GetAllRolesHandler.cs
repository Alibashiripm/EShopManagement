using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Application.DTOs.User.Admin;
using EShopManagement.Application.Queries.ProductComment;
using EShopManagement.Application.Queries.Role;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.Role
{

    internal sealed class GetAllRolesHandler : IQueryHandler<GetAllRoles, List<AdminAllRoleDto>>
    {
        private readonly DbSet<Domain.Entities.User.Role> _roles;


        public GetAllRolesHandler(ReadDbContext context)
        {
            _roles = context.Roles;
        }
        public async Task<List<AdminAllRoleDto>> HandleAsync(GetAllRoles query)
        {
             return await _roles
                .OrderBy(r=>r.Name)
            
                 .Select(s => s.AsAdminAllRoleDto())
                 .AsNoTracking()
                 .ToListAsync();
        }
    }
}
