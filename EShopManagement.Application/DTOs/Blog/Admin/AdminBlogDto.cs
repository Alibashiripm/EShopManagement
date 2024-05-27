using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.Blog.Admin
{
    public class AdminBlogDto
    {
        public int Id { get;   set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageName { get; set; }
        public string ShortDescription { get; set; }
        public string Tags { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
