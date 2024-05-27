
using EShopManagement.Shared.Abstractions.Domain;
using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Entities.User;
using EShopManagement.Domain.ValueObjects.Blog;
using EShopManagement.Domain.ValueObjects.Product;
using System.Diagnostics;

namespace EShopManagement.Domain.Entities.Product
{
    public class Product : AggregateRoot<int>
    {
        public int  Id { get;private set; }
        public ProductTitle _title;
        public ProductDescription _description;
        public ProductShortDescription _shortDescription;
        public ProductFileName? _fileName;
        public ProductPrice _price;
        public string Tags { get; }
        public string ImageName { get; }
        public int? SubCategoryId { get;}
        public int CategoryId { get; }
        public long CellerId { get;}
        public bool IsAvailable { get;}
        public bool IsPremium { get; }
        public bool IsDeleted { get; private set; } = false;

        public ProductCreateDate _createDate;
        public ProductUpdateDate? _updateDate;
        #region Relations
        public   ProductCategory ProductCategory { get; set; }
        public   ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<User.User> Users { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
        #endregion
     
    internal Product(  ProductTitle title, ProductDescription description, ProductShortDescription shortDescription,
                 ProductFileName? fileName, ProductPrice price, string tags, int? subCategoryId, int categoryId, long cellerId,
                 bool isAvailable, bool isPremium, ProductCreateDate createDate, ProductUpdateDate? updateDate, string imageName)
    {
            ImageName = imageName;
           _title = title;
        _description = description;
         _shortDescription = shortDescription;
       _fileName = fileName;
        _price = price;
        Tags = tags;
        SubCategoryId = subCategoryId;
        CategoryId = categoryId;
        CellerId = cellerId;
        IsAvailable = isAvailable;
        IsPremium = isPremium;
        _createDate = createDate;
        _updateDate = updateDate;
     
    }
        public Product()
        {
            
        }
        public void SoftDelete()
        {
            IsDeleted = true;
        }
    }
}
