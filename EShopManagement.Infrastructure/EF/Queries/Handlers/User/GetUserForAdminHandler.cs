using EShopManagement.Application.DTOs.User.Admin;
using EShopManagement.Application.Queries.User;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.User
{
    internal sealed class GetUserForAdminHandler : IQueryHandler<GetUserForAdmin, AdminUserDto>
    {
        private readonly DbSet<Domain.Entities.User.User> _users;


        public GetUserForAdminHandler(ReadDbContext context)
        {
            _users = context.Users;
        }
        public async Task<AdminUserDto> HandleAsync(GetUserForAdmin query)
        {
            var user =await _users
                  .IgnoreQueryFilters()
                  .AsNoTracking()
                  .SingleOrDefaultAsync(u => u.Id == query.UserId);
            return user.AsAdminUserDto();
        }
    }
}
