using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.Blog
{
    public class GetAllBlogsForAdmin: IQuery<List<AdminBlogsListDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int TakeNumber { get; set; } = 1;
        public string SearchPhrase { get; set; } = "";
        public string OrderBy { get; set; } = "date";
    } 
   
}
