
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Domain.Factories.Order;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.OrderDetail.Handlers
{
    internal class CreateOrderDetailHandler : ICommandHandler<CreateOrderDetail>
    {
        private readonly IGenericRepository<Domain.Entities.Order.OrderDetail, int> repository;
        private readonly IOrderDetailFactory factory;

        public CreateOrderDetailHandler(IGenericRepository<Domain.Entities.Order.OrderDetail,int> repository , IOrderDetailFactory factory)
        {
            this.repository = repository;
            this.factory = factory;
        }
        public async Task HandleAsync(CreateOrderDetail command)
        {
            var orderDetail = command.DetailDto;
            var orderDetailEntity = factory.Create(orderDetail.OrderId, orderDetail.ProductId, orderDetail.Price);
            await repository.CreateAsync(orderDetailEntity);
        }
    } 
}
