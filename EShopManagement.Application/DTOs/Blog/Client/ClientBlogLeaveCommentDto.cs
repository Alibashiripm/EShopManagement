namespace EShopManagement.Application.DTOs.Blog.Client
{
    public class ClientBlogLeaveCommentDto
    {
        public int UserId { get; set; }
        public string Content{ get; set; }
        public int BlogId{ get; set; }// Blog Id
        
    }
}
