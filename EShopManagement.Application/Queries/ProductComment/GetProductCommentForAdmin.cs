using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.ProductComment
{
    public class GetProductCommentForAdmin : IQuery<AdminProductCommentDto>
    {
        public int CommentId { get; set; }
    }
}
