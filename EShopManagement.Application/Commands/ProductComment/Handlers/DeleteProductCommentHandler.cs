using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Domain.Repositories;

namespace EShopManagement.Application.Commands.ProductComment.Handlers
{
    internal sealed class DeleteProductCommentHandler : ICommandHandler<DeleteProductComment>
    {
        private readonly IGenericRepository<Domain.Entities.Product.ProductComment,int> _repository;

        public DeleteProductCommentHandler(IGenericRepository<Domain.Entities.Product.ProductComment, int>  repository)
        {
            _repository =  repository;
        }
        public async Task HandleAsync(DeleteProductComment command)
        {
            await _repository.DeleteAsync(command.ProductCommentId);
        }
    }
}
