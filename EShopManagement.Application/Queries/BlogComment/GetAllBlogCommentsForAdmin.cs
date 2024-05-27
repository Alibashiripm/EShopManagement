using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Shared.Abstractions.Queries;

namespace EShopManagement.Application.Queries.BlogComment
{
    public class GetAllBlogCommentsForAdmin : IQuery<List<AdminBlogCommentDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int TakeNumber { get; set; } = 1;
    
        public List<int>? BlogIds { get; set; }= new List<int>();
        public bool IsConfirmed { get; set; }  
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }=DateTime.Now;
       
    }

}
