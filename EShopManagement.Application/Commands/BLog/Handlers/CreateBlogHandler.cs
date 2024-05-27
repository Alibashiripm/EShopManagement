using AutoMapper;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Exceptions;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Entities.Blog;
using EShopManagement.Domain.Factories.Blog;
using EShopManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.BLog.Handlers
{
    internal sealed class CreateBlogHandler : ICommandHandler<CreateBlog>
    {
        private readonly IGenericRepository<Blog, int> _genericRepository;
 
        private readonly IBlogFactory _factory;
        private readonly IBlogService service;

        public CreateBlogHandler(IGenericRepository<Blog, int> genericRepository, 
                                 IBlogFactory factory,IBlogService service)
        {
            _factory = factory;
            this.service = service;
            _genericRepository = genericRepository;
   
        }
        public async Task HandleAsync(CreateBlog command)
        {
            if (await service.IsBlogExistWithTitleAsync(command.BlogDto.Title))
            {
                throw new AlreadyExistsException("Blog", command.BlogDto.Title);
            }
             var blog = _factory.Create(command.BlogDto.ImageName, command.BlogDto.Title, command.BlogDto.Content, command.BlogDto.ShortDescription, command.BlogDto.Tags, command.BlogDto.CreateDate, command.BlogDto.UpdateDate, command.BlogDto.IsDeleted) ;
             await  _genericRepository.CreateAsync(blog);
        }
    }  
}
