using EShopManagement.Application.Services;
using EShopManagement.Domain.Factories.User;
using EShopManagement.Shared.Abstractions.Commands;
using System.Runtime.InteropServices;

namespace EShopManagement.Application.Commands.User.Handlers
{
    internal sealed class PremiumSubscriptionHandler : ICommandHandler<PremiumSubscription,bool>
    {
        private readonly IUserFactory factory;
        private readonly IUserService userService;

        public PremiumSubscriptionHandler(IUserFactory factory, IUserService userService)
        {
             this.userService = userService;
        }
        public async Task<bool>  HandleAsync(PremiumSubscription command)
        {
       return  await userService.PremiumSubscriptionAsync(command.OrderId,command.UserId,command.reuestQueries);
 
        }
    }
}
