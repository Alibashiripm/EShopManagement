using EShopManagement.Application.Services;
using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Factories.User;
using EShopManagement.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.Order.Handlers
{
    internal sealed class PremiumSubscriptionPaymentHandler : ICommandHandler<PremiumSubscriptionPayment, string>
    {
        private readonly IUserFactory factory;
        private readonly IUserService userService;

        public PremiumSubscriptionPaymentHandler(IUserFactory factory, IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<string> HandleAsync(PremiumSubscriptionPayment command)
        {
            var result = await userService.PremiumSubscriptionPaymentAsync(command.Email, 30000, command.Description, command.CallBackUrl, command.OrderId);
            return result;
        }
    }
}
