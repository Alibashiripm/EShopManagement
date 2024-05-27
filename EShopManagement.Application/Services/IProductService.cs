using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Services
{
    public interface IProductService
    {
        Task ConfrimProductCommentAsync(int CommentId);
        Task<bool> IsProductExistWithIdAsync(int productId);
        Task<bool> IsProductExistWithTitleAsync(string title);
    }
}
