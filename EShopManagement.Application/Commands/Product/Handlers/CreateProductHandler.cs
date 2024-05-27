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

namespace EShopManagement.Application.Commands.Product.Handlers
{
    internal sealed class CreateProductHandler : ICommandHandler<CreateProduct>
    {
        private readonly IProductFactory factory;
        private readonly IGenericRepository<Domain.Entities.Product.Product, int> repository;
        private readonly IProductService service;

        public CreateProductHandler(IProductFactory factory,IGenericRepository<Domain.Entities.Product.Product,int> repository,IProductService service)
        {
            this.factory = factory;
            this.repository = repository;
            this.service = service;
        }
        public async Task HandleAsync(CreateProduct command)
        {
            if (await service.IsProductExistWithTitleAsync(command.PtoductDto.Title))
            {
                throw new AlreadyExistsException("Ptoduct", command.PtoductDto.Title);
            }
            var productDto = command.PtoductDto;
            var product = factory.Create(
                productDto.Title, productDto.Description, productDto.ShortDescription,
                productDto.FileName, productDto.Price, productDto.Tags, productDto.SubCategoryId,
                productDto.CategoryId, productDto.CellerId, productDto.IsAvailable, productDto.IsPremium,
                productDto.CreateDate, productDto.UpdateDate,productDto.ImageName);
            await repository.CreateAsync(product);
        }
    } 
}
