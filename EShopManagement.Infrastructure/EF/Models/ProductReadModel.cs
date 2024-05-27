using EShopManagement.Domain.Entities.User;

namespace EShopManagement.Infrastructure.EF.Models
{
    internal class ProductReadModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description{ get; set; }
        public string ShortDescription{ get; set; }
        public string? FileName{ get; set; }
        public string ImageName{ get; set; }
        public decimal Price{ get; set; }
        public TagsReadModel Tags { get; set; }
        public int? SubCategoryId{ get; set; }
        public int CategoryId { get; set; }
        public long CellerId { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsPremium { get; set; }
        public bool IsDeleted{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime? UpdateDate{ get; set; }
        public ProductCategoryReadModel ProductCategory { get; set; }
        public ICollection<ProductCommentReadModel> ProductComments { get; set; }
        public ICollection<UserReadModel> Users { get; set; }
        public ICollection<OrderDetailReadModel> OrderDetails{ get; set; }
    }
}
