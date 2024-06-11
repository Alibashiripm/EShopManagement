using EShopManagement.Application.DTOs.User.Client;
using EShopManagement.Application.Queries.User;
using EShopManagement.Infrastructure.EF.Contexts;

using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.User
{
    internal sealed class GetUserAavtarForClientHandler : IQueryHandler<GetUserAavtarForClient, ClientEditUserAvatarDto>
    {
        private readonly DbSet<Domain.Entities.User.User> _users;


        public GetUserAavtarForClientHandler(ReadDbContext context)
        {
            _users = context.Users;
        }
        public async Task<ClientEditUserAvatarDto> HandleAsync(GetUserAavtarForClient query)
        {
            var user =await _users
                  .IgnoreQueryFilters()
                   .AsNoTracking()
                  .SingleOrDefaultAsync(u => u.Id == query.UserId);
            return user.AsClientEditUserAvatarDto();
        }
    }  
}
