using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.Blog.Client
{
    public class ClientBlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags{ get; set; }
        public string ShortDescription { get; set; }
        public string ImageName { get; set; }
        public List<ClientBlogCommentDto> Comments{ get; set; }

    }
}
