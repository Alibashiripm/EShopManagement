namespace EShopManagement.Infrastructure.EF.Models
{
    internal class BlogCommentReadModel
    {
        public int Id { get; set; }
        public string Content { get; set;}
    
        public DateTime CreateDate { get; set;}
        public bool IsConfirmed { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public UserReadModel User { get; set; }
        public BlogReadModel Blog { get; set; }
     
    }
}
