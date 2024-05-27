using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Exceptions;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.ProductCategory.Handler
{
    internal sealed class DeleteProductCategoryHandler : ICommandHandler<DeleteProductCategory>
    {
        private readonly IProductService service;
        private readonly IGenericRepository<Domain.Entities.Product.ProductCategory, int> repository;

        public DeleteProductCategoryHandler(IProductService service,IGenericRepository<Domain.Entities.Product.ProductCategory,int> repository)
        {
            this.service = service;
            this.repository = repository;
        }
        public async Task HandleAsync(DeleteProductCategory command)
        {
            if (!await service.IsProductExistWithIdAsync(command.CategoryId))
            {
                throw new EntityNotFoundExeption("ProductCategory", command.CategoryId.ToString());
            }
           
            await repository.DeleteAsync(command.CategoryId);
        }
    }
}
