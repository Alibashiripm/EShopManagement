using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Commands.BLog;
using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Factories.Order;
using EShopManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.Order.Handlers
{
    internal sealed class CreateOrderHandler : ICommandHandler<CreateOrder>
    {
        private readonly IOrderFactory _factory;
        private readonly IGenericRepository<Domain.Entities.Order.Order, int> _repository;

        public CreateOrderHandler(IOrderFactory factory,IGenericRepository<Domain.Entities.Order.Order,int> repository)
        {
            _factory = factory;
            _repository = repository;
        }
        public async Task HandleAsync(CreateOrder command)
        {
            var order = command.Order;
            var orderEntity = _factory.Create(order.OrderSum ,order.IsFinaly, DateTime.Now, order.UserId);
            await _repository.CreateAsync(orderEntity);
        }
    }  
}
