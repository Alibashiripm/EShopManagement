using AutoMapper;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Exceptions;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.Product.Handlers
{
    internal sealed class UpdateProductHandler : ICommandHandler<UpdateProduct>
    {
 
        private readonly IGenericRepository<Domain.Entities.Product.Product, int> repository;
        private readonly IMapper mapper;
        private readonly IProductService service;

        public UpdateProductHandler( IGenericRepository<Domain.Entities.Product.Product,int> repository,IMapper mapper,IProductService service)
        {
      this.mapper = mapper;
            this.service = service;
            this.repository = repository;
        }
        public async Task HandleAsync(UpdateProduct command)
        {
            if (!await service.IsProductExistWithIdAsync(command.PtoductDto.ProductId))
            {
                throw new EntityNotFoundExeption("Ptoduct", command.PtoductDto.ProductId.ToString());
            }
            if (await service.IsProductExistWithTitleAsync(command.PtoductDto.Title))
            {
                throw new AlreadyExistsException("Ptoduct", command.PtoductDto.Title);
            }
            var productDto = command.PtoductDto;
           var product= mapper.Map<Domain.Entities.Product.Product>(productDto);
   
            await repository.UpdateAsync(product);
        }
    }
}
