
namespace EShopManagement.Infrastructure.EF.Models
{
    internal class BlogReadModel
    {
        public int Id { get; set; }
        public string Title{ get; set; }
        public string Content{ get; set; }
        public string ShortDescription{ get; set; }
        public string ImageName{ get; set; }
        public TagsReadModel Tags { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate{ get; set; }
        public bool IsDeleted { get; set; }
        public List<BlogCommentReadModel> BlogComments { get; set; }
 
    }
}
