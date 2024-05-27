using AutoMapper;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Exceptions;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.ProductCategory.Handler
{
    internal sealed class UpdateProductCategoryHandler : ICommandHandler<UpdateProductCategory>
    {
        private readonly IProductService service;
        private readonly IGenericRepository<Domain.Entities.Product.ProductCategory, int> repository;
        private readonly IMapper mapper;

        public UpdateProductCategoryHandler(IProductService service,IGenericRepository<Domain.Entities.Product.ProductCategory,int> repository,IMapper mapper)
        {
            this.service = service;
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task HandleAsync(UpdateProductCategory command)
        {
            if (!await service.IsProductExistWithIdAsync(command.CategoryDto.CategoryId))
            {
                throw new EntityNotFoundExeption("ProductCategory", command.CategoryDto.CategoryId.ToString());
            }
            if (await service.IsProductExistWithTitleAsync(command.CategoryDto.Title))
            {
                throw new AlreadyExistsException("ProductCategory", command.CategoryDto.Title);
            }
            var category = mapper.Map<Domain.Entities.Product.ProductCategory>(command.CategoryDto);
            await repository.UpdateAsync(category);

                
        }
    } 
}
