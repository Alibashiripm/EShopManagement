using EShopManagement.Application.DTOs.Blog.Client;
using EShopManagement.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Queries.Blog
{
    public class GetBlogsForClient: IQuery<List<ClientBlogsListDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int TakeNumber { get; set; } = 1;
        public string SearchPhrase { get; set; } = "";
        public string OrderBy { get; set; } = "date";
     } 
   
   
}
