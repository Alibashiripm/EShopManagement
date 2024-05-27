using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.BlogComment
{
    public class GetBlogCommentForAdmin : IQuery<AdminBlogCommentDto>
    {
        public int CommentId { get; set; }
    } 

}
