namespace EShopManagement.Infrastructure.EF.Models
{
    internal class OrderDetailReadModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public OrderReadModel Order { get; set; }
        public ProductReadModel Product { get; set; }
        public bool IsDeleted { get; set; }
    }
}
