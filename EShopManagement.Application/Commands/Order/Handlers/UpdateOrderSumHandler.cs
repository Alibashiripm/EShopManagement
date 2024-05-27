using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.Order.Handlers
{
    internal sealed class UpdateOrderSumHandler : ICommandHandler<UpdateOrderSum>
    {
        private readonly IOrderService service;
        private readonly IGenericRepository<Domain.Entities.Order.Order, int> repository;

        public UpdateOrderSumHandler(IOrderService service,IGenericRepository<Domain.Entities.Order.Order,int> repository)
        {
            this.service = service;
            this.repository = repository;
        }
        public async Task HandleAsync(UpdateOrderSum command)
        {
            var order = await service.UpdateOrderSumAsync(command.OrderId);
            await repository.UpdateAsync(order);
        }
    }
}
