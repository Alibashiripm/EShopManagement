using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.Blog.Admin
{
    public class AdminBlogCommentDto
    {
        public int CommentId { get; set; }
        public string Content{ get; set; }
        public bool IsConfirmed { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }

    }
}
