using EShopManagement.Application.DTOs.Blog.Client;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.BlogComment
{
    public class GetBlogCommentsForClient : IQuery<List<ClientBlogCommentDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int TakeNumber { get; set; } = 1;
        public int BlogId { get; set; }
    }

}
