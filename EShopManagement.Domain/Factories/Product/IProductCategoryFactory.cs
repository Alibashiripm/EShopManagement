using EShopManagement.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Factories.Product
{
    public interface IProductCategoryFactory
    {
        ProductCategory Create( string title, bool isDelete, int? parentId);
    }
}
