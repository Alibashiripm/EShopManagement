using EShopManagement.Application.DTOs.Blog.Client;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.Blog
{
    public class GetBlogForClient: IQuery<ClientBlogDto>
    {
        public string BlogTitle { get; set; }
    }  
   
}
