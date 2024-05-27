using EShopManagement.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Factories.Product
{
    public class ProductCategoryFactory : IProductCategoryFactory
    {
        public ProductCategory Create(string title, bool isDelete, int? parentId)
        => new(title,isDelete,parentId);
    }
}
