using EShopManagement.Application.DTOs.User.Admin;
using EShopManagement.Application.Queries.Role;
using EShopManagement.Application.Queries.User;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.User
{

    internal sealed class GetAllUsersForAdminHandler : IQueryHandler<GetAllUsersForAdmin, List<AdminUsersListDto>>
    {
        private readonly DbSet<Domain.Entities.User.User> _users;


        public GetAllUsersForAdminHandler(ReadDbContext context)
        {
            _users = context.Users;
        }
        public async Task<List<AdminUsersListDto>> HandleAsync(GetAllUsersForAdmin query)
        {
            int skip = (query.PageNumber - 1) * query.TakeNumber;
            return await _users
                 .IgnoreQueryFilters()
                 .Where(b => 
                 b.UserName.Contains(query.UserName) ||
                 b.Email.Contains(query.Email) ||
                
                 b.EmailConfirmed == query.IsActived)
                 .Include(u=>u.UserPremium)
 
                 .OrderBy(o => o.RegistrationDate)
                 .Skip(skip)
                 .Take(query.TakeNumber)
                 .Select(s => s.AsAdminUsersListDto())
                 .AsNoTracking()
                 .ToListAsync();
        }
    }  
}
