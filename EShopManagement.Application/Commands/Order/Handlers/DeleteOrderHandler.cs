using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.Order.Handlers
{
    internal sealed class DeleteOrderHandler : ICommandHandler<DeleteOrder>
    {
         private readonly IGenericRepository<Domain.Entities.Order.Order, int> _repository;

        public DeleteOrderHandler(IGenericRepository<Domain.Entities.Order.Order,int> repository)
        {
             _repository = repository;
        }
        public async Task HandleAsync(DeleteOrder command)
        {
              await _repository.DeleteAsync(command.OrderId);
        }
    }
}
