using EShopManagement.Domain.Entities.Blog;
using EShopManagement.Domain.ValueObjects.BlogComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Factories.Blog
{
    public interface IBlogCommentFactory
    {
        BlogComment Create(BlogCommentContent content, BlogCommentCreateDate createDate, bool isConfirmed,
                    int blogId, int userId);
    }
}
