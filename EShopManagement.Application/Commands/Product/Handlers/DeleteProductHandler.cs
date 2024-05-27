using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Exceptions;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.Product.Handlers
{
    internal sealed class DeleteProductHandler : ICommandHandler<DeleteProduct>
    {
        
        private readonly IGenericRepository<Domain.Entities.Product.Product, int> repository;
        private readonly IProductService service;

        public DeleteProductHandler( IGenericRepository<Domain.Entities.Product.Product,int> repository,IProductService service)
        {
            this.repository = repository;
            this.service = service;
        }
        public async Task HandleAsync(DeleteProduct command)
        {
            if (!await service.IsProductExistWithIdAsync(command. ProductId))
            {
                throw new EntityNotFoundExeption("Ptoduct", command.ProductId.ToString());
            }
            await repository.DeleteAsync(command.ProductId);
        }
    }
}
