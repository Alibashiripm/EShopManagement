using EShopManagement.Application.DTOs.Order;
using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.Product
{
    public class GetAllProductsForAdmin : IQuery<List<AdminPtoductsListDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int TakeNumber { get; set; } = 1;
        public string SearchPhrase { get; set; } = "";
        public string OrderBy { get; set; } = "date";
        public List<int>? CategoryIds{ get; set; }  
    }  
}
