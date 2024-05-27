using AutoMapper;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.Order.Handlers
{
    internal sealed class UpdateOrderHandler : ICommandHandler<UpdateOrder>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Domain.Entities.Order.Order, int> _repository;

        public UpdateOrderHandler(IMapper mapper, IGenericRepository<Domain.Entities.Order.Order,int> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task HandleAsync(UpdateOrder command)
        {
            var order = command.Order;
            var orderEntity = _mapper.Map<Domain.Entities.Order.Order>(order);
            await _repository.UpdateAsync(orderEntity);
        }
    }  
}
