using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.Blog.Client
{
    public class ClientBlogCommentDto
    {
        public string UserName{ get; set; }
        public string Content{ get; set; }
        public string UserAvatarName{ get; set; }
        public string CommentedFor{ get; set; }// Blog Title
        
    } 
}
