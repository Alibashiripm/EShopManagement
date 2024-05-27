using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.Blog
{
    public class GetBlogForAdmin: IQuery<AdminBlogDto>
    {
        public int BlogId{ get; set; }
    } 

}
