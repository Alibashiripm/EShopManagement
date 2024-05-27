
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Domain.Factories.Order;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.OrderDetail.Handlers
{
    internal class DeleteOrderDetailHandler : ICommandHandler<DeleteOrderDetail>
    {
        private readonly IGenericRepository<Domain.Entities.Order.OrderDetail, int> repository;
        public DeleteOrderDetailHandler(IGenericRepository<Domain.Entities.Order.OrderDetail,int> repository , IOrderDetailFactory factory)
        {
            this.repository = repository;
       
        }
        public async Task HandleAsync(DeleteOrderDetail command)
        {
            await repository.DeleteAsync(command.DetailId);
        }
    }
}
