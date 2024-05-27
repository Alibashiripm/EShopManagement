using AutoMapper;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Exceptions;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.BLog.Handlers
{
    internal sealed class DeleteBlogHandler : ICommandHandler<DeleteBlog>
    {
        private readonly IGenericRepository<Domain.Entities.Blog.Blog, int> _genericRepository;
        private readonly IBlogService service;

        public DeleteBlogHandler(IGenericRepository<Domain.Entities.Blog.Blog, int> genericRepository,IBlogService service )
        {
            _genericRepository = genericRepository;
            this.service = service;
        }
        public async Task HandleAsync(DeleteBlog command)
        {
            if (!await service.IsBlogExistWithIdAsync(command.Blogid))
            {
                throw new EntityNotFoundExeption("Blog", command.Blogid.ToString());
            }
            await  _genericRepository.DeleteAsync(command.Blogid);
        }
    }
}
