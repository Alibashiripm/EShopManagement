using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Services
{
    public interface IBlogService
    {
        Task ConfrimBlogCommentAsync(int CommentId);
        Task<bool> IsBlogExistWithTitleAsync(string BlogTitle);
        Task<bool> IsBlogExistWithIdAsync(int BlogId);
    }
}
