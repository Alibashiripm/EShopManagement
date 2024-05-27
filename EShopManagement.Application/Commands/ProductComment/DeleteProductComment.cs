using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.ProductComment
{
    public record DeleteProductComment(int ProductCommentId) :ICommand;
}
