using EShopManagement.Shared.Abstractions.Domain;
using EShopManagement.Domain.ValueObjects.Blog;
using EShopManagement.Domain.ValueObjects.BlogComment;

namespace EShopManagement.Domain.Entities.Blog
{
    public class BlogComment: AggregateRoot<int>
    {
 
        public int Id { get;private set; }

        public BlogCommentContent _content;
        public BlogCommentCreateDate _createDate;
        public bool IsConfirmed { get; private set; }
        #region relations
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public Blog Blog { get; set; }
        public   User.User User { get; set; }
        #endregion
        public BlogComment(BlogCommentContent content, BlogCommentCreateDate createDate, bool isConfirmed,
                    int blogId, int userId)
        {
           
            _content = content;
            _createDate = createDate;
            IsConfirmed = isConfirmed;
            BlogId = blogId;
            UserId = userId;
        }
        public BlogComment()
        {
            
        }

        public void RemoveConfirmation()
        {
            IsConfirmed = false;
        }
        public void Confrim()
        {
            IsConfirmed = true;
        }
    }
}
