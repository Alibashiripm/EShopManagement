using AutoMapper;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Exceptions;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Entities.Blog;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.BLog.Handlers
{
    internal sealed class UpdateBlogHandler : ICommandHandler<UpdateBLog>
    {
        private readonly IGenericRepository<Domain.Entities.Blog.Blog, int> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IBlogService service;

        public UpdateBlogHandler(IGenericRepository<Domain.Entities.Blog.Blog, int> genericRepository,IMapper mapper, IBlogService service)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            this.service = service;
        }
        public async Task HandleAsync(UpdateBLog command)
        {

            if (!await service.IsBlogExistWithIdAsync(command.BlogDto.Id))
            {
                throw new EntityNotFoundExeption("Blog", command.BlogDto.Id.ToString());
            } 
            if (await service.IsBlogExistWithTitleAsync(command.BlogDto.Title))
            {
                throw new AlreadyExistsException("Blog", command.BlogDto.Title);
            }
            var blog=  _mapper.Map<Blog>(command.BlogDto);
             await  _genericRepository.UpdateAsync(blog);
        }
    }  
}
