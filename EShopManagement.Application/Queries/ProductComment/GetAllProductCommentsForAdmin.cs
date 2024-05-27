using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Queries.ProductComment
{
    public class GetAllProductCommentsForAdmin : IQuery<List<AdminProductCommentDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int TakeNumber { get; set; } = 1;

        public List<int>? ProductIds { get; set; }= new List<int>();
        public bool IsConfirmed { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.Now;
    } 
}
