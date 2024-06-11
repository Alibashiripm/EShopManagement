using EShopManagement.Application.Queries.Blog;
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EShopManagement.WebMVC.ViewComponents
{
    public class BlogsComponent:ViewComponent
    {  
        private readonly IQueryDispatcher _queryDispatcher;
        public BlogsComponent( IQueryDispatcher queryDispatcher)
        {
             _queryDispatcher = queryDispatcher;
        }
 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            GetBlogsForClient query = new() {PageNumber = 1,TakeNumber=8};
            var result = await _queryDispatcher.QueryAsync(query);
            return await Task.FromResult((IViewComponentResult)View("Blogs", result));
        }
    }
}
