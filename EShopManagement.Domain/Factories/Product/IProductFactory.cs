using EShopManagement.Domain ;
using EShopManagement.Domain.ValueObjects.Blog;
using EShopManagement.Domain.ValueObjects.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Domain.Factories.Product
{
    public interface IProductFactory
    {
        Entities.Product.Product Create(ProductTitle title, ProductDescription description, ProductShortDescription shortDescription,
                 ProductFileName? fileName, ProductPrice price, string tags, int? subCategoryId, int categoryId, long cellerId,
                 bool isAvailable, bool isPremium, ProductCreateDate createDate, ProductUpdateDate? updateDate,string imageName);
    }
}
