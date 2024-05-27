namespace EShopManagement.Infrastructure.EF.Models
{
    internal class ProductCategoryReadModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public int? ParentId { get; set; }
        public List<ProductReadModel> Products { get; set; }
        public List<ProductCategoryReadModel>  ProductCategories { get; set; }

    }
}
