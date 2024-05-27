using EShopManagement.Shared.Abstractions.Domain;

namespace EShopManagement.Domain.Entities.Product
{
    public class ProductCategory : AggregateRoot<int>
    {
        public int  Id { get;private set; }
        public string Title { get;  }
        public bool IsDeleted { get; private set; }
        public int? ParentId { get;  }
        public List<ProductCategory> ProductCategories { get; set; }
        public  List<Product> Products { get; set; }
        internal ProductCategory(  string title, bool isDeleted, int? parentId)
        {
            
            Title = title;
            IsDeleted = isDeleted;
            ParentId = parentId;
        
        }
        public ProductCategory()
        {
            
        }

        public void SoftDelete()
        {
            IsDeleted = true;
        }
    }
}
