using AutoMapper;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Domain.Factories.Blog;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.BlogComment.Handlers
{
    internal sealed class LeaveCommentHandler : ICommandHandler<LeaveComment>
    {
        private readonly IGenericRepository<Domain.Entities.Blog.BlogComment, int> _genericRepository;
        private readonly IBlogCommentFactory _factory;

        public LeaveCommentHandler(IGenericRepository<Domain.Entities.Blog.BlogComment, int> genericRepository, IBlogCommentFactory factory)
        {
            _genericRepository = genericRepository;
            _factory = factory;
        }
        public async Task HandleAsync(LeaveComment command)
        {
            var commentDto = command.CommentDto;
            var comment = _factory.Create(commentDto.Content, DateTime.Now, false, commentDto.BlogId, commentDto.UserId);
            await _genericRepository.CreateAsync(comment);
        }
    }
}
