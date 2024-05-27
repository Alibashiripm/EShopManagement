using EShopManagement.Application.DTOs.Product.Client;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.ProductComment
{
    public class GetProductCommentsForClient : IQuery<List<ClientProductCommentDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int TakeNumber { get; set; } = 1;
        public int ProductId { get; set; }
    }
}
