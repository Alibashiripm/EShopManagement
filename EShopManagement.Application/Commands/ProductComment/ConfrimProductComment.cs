using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.ProductComment
{
    public record ConfrimProductComment(int ProductCommentId) :ICommand;
}
