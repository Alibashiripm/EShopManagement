using EShopManagement.Domain.Entities.Product;
using EShopManagement.Domain.ValueObjects.ProductComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Factories.Product
{
    public class ProductCommentFactory : IProductCommentFactory
    {
        public ProductComment Create(ProductCommentContent content, ProductCommentCreateDate createDate, bool isConfirmed,
                    long blogId, long userId)
      => new(content,createDate, isConfirmed,blogId,userId);
    }
}
