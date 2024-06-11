using EShopManagement.Application.Queries.Product;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EShopManagement.WebMVC.ViewComponents
{
    public class ProductsComponent:ViewComponent
    {
       
        private readonly IQueryDispatcher _queryDispatcher;

        public ProductsComponent( IQueryDispatcher queryDispatcher)
        {
             _queryDispatcher = queryDispatcher;
        }
 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            GetAllProductsForClient query = new() {PageNumber = 1,TakeNumber=8};
            var result = await _queryDispatcher.QueryAsync(query);

            return await Task.FromResult((IViewComponentResult)View("Products", result.ToList()));
        }
    }
}
