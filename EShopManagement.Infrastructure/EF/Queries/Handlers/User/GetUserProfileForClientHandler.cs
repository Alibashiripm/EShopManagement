using EShopManagement.Application.DTOs.User.Client;
using EShopManagement.Application.Queries.User;
using EShopManagement.Infrastructure.EF.Contexts;

using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.User
{
    internal sealed class GetUserProfileForClientHandler : IQueryHandler<GetUserProfileForClient, ClientUserDto>
    {
        private readonly DbSet<Domain.Entities.User.User> _users;


        public GetUserProfileForClientHandler(ReadDbContext context)
        {
            _users = context.Users;
        }
        public async Task<ClientUserDto> HandleAsync(GetUserProfileForClient query)
        {
            var user =await _users
                  .IgnoreQueryFilters()
                  .Include(u => u.UserPremium)
                  .AsNoTracking()
                  .SingleOrDefaultAsync(u => u.Id == query.UserId);
            return user.AsClientUserDto();
        }
    }   
}
