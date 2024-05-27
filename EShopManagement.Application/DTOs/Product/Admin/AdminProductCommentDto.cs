using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.DTOs.Product.Admin
{
    public class AdminProductCommentDto
    {
        public int CommentId { get;   set; }

        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsConfirmed { get; set; }

        public int ProductId { get; set; }
        public int UserId { get; set; }
     
    }
}
