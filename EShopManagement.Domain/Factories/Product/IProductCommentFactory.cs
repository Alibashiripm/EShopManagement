using EShopManagement.Domain.Entities.Product;
using EShopManagement.Domain.ValueObjects.ProductComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Factories.Product
{
    public interface IProductCommentFactory
    {
        ProductComment Create(ProductCommentContent content, ProductCommentCreateDate createDate, bool isConfirmed,
                    long productId, long userId);
    }
}
