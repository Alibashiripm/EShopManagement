using EShopManagement.Application.DTOs.Product.Client;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.Product
{
    public class GetProductForClient : IQuery<ClientProductDto>
    {
        public string Title{ get; set; }
    }
}
