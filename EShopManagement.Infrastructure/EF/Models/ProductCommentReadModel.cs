using EShopManagement.Domain.Entities.Product;

namespace EShopManagement.Infrastructure.EF.Models
{
    internal class ProductCommentReadModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsConfirmed { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public UserReadModel User { get; set; }
        public ProductReadModel Product { get; set; }
        public bool IsDeleted { get;  set; }
    }
}
