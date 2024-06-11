using EShopManagement.Application.Queries.Product;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EShopManagement.WebMVC.ViewComponents
{
    public class PaidProductsComponent:ViewComponent
    {
       
        private readonly IQueryDispatcher _queryDispatcher;

        public PaidProductsComponent( IQueryDispatcher queryDispatcher)
        {
             _queryDispatcher = queryDispatcher;
        }
 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            GetAllProductsForClient query = new() {PageNumber = 1,TakeNumber=8};
            var result = await _queryDispatcher.QueryAsync(query);
            
            return await Task.FromResult((IViewComponentResult)View("Products", result.Where(p=>p.Price!= 0).ToList()));
        }
    }
}
