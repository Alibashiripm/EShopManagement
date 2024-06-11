using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Consts;

namespace EShopManagement.Application.Commands.Order.Handlers
{
    internal sealed class ApplyDiscountHandler : ICommandHandler<ApplyDiscount, DiscountResponseType>
    {
        private readonly IOrderService service;
      
        public ApplyDiscountHandler(IOrderService service)
        {
            this.service = service;
         }
        public async Task<DiscountResponseType> HandleAsync(ApplyDiscount command)
        {
            return await service.ApplyDiscount(command.OrderId,command.Code);
       
        }
    }
}
