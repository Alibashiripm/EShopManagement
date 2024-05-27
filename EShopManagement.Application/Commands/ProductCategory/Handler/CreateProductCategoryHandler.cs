using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Exceptions;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Factories.Product;
using EShopManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.ProductCategory.Handler
{
    internal sealed class CreateProductCategoryHandler : ICommandHandler<CreateProductCategory>
    {
        private readonly IGenericRepository<Domain.Entities.Product.ProductCategory, int> repository;
        private readonly IProductService service;
        private readonly IProductCategoryFactory factory;

        public CreateProductCategoryHandler(IGenericRepository<Domain.Entities.Product.ProductCategory,int> repository,IProductService service, IProductCategoryFactory factory)
        {
            this.repository = repository;
            this.service = service;
            this.factory = factory;
        }
        public async Task HandleAsync(CreateProductCategory command)
        {
            
            if (await service.IsProductExistWithTitleAsync(command.CategoryDto.Title))
            {
                throw new AlreadyExistsException("ProductCategory", command.CategoryDto.Title);
            }
            var ctegoryDto = command.CategoryDto;
            var category = factory.Create(ctegoryDto.Title, false, ctegoryDto.ParentId);
            await repository.CreateAsync(category);
        }
    }  
}
