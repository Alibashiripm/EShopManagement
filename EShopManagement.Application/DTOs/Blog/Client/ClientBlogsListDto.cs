using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.Blog.Client
{
    public class ClientBlogsListDto
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
 
}
