using EShopManagement.Application.Queries.ProductCategory;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EShopManagement.WebMVC.ViewComponents
{
    public class ProductCategoriesComponent:ViewComponent
    {
       
        private readonly IQueryDispatcher _queryDispatcher;

        public ProductCategoriesComponent( IQueryDispatcher queryDispatcher)
        {
             _queryDispatcher = queryDispatcher;
        }
 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            GetAllProductCategories query = new();
            var result = await _queryDispatcher.QueryAsync(query);

            return await Task.FromResult((IViewComponentResult)View("ProductCategories", result));
        }
    }  
}
