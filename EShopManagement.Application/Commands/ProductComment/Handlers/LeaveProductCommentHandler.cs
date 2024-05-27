using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Domain.Factories.Product;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.ProductComment.Handlers
{
    internal sealed class LeaveProductCommentHandler : ICommandHandler<LeaveProductComment>
    {
        private readonly IProductCommentFactory factory;
        private readonly IGenericRepository<Domain.Entities.Product.ProductComment,int> _repository;

        public LeaveProductCommentHandler(IProductCommentFactory factory,IGenericRepository<Domain.Entities.Product.ProductComment, int>  repository)
        {
            this.factory = factory;
            _repository =  repository;
        }
        public async Task HandleAsync(LeaveProductComment command)
        {
            var commentDto = command.CommentDto;
            var comment = factory.Create(commentDto.Content, commentDto.CreateDate, false, commentDto.ProductId, commentDto.UserId);
            await _repository.CreateAsync(comment);
        }
    }
}
