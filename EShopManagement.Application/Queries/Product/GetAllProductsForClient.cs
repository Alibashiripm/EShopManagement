using EShopManagement.Application.DTOs.Product.Client;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.Product
{
    public class GetAllProductsForClient : IQuery<List<ClientProductsListDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int TakeNumber { get; set; } = 1;
        public string SearchPhrase { get; set; } = "";
        public List<int>? CategoryIds { get; set; }
        public string OrderBy { get; set; } = "date";
    }  
}
