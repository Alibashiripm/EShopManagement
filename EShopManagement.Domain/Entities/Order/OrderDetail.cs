using EShopManagement.Shared.Abstractions.Domain;

namespace EShopManagement.Domain.Entities.Order
{
    public class OrderDetail : AggregateRoot<int>
    {

        public int Id { get;private set; }
        public int OrderId { get; private set; }
        public int? ProductId { get; private set; }
        public decimal Price { get;private set; }
        public Order Order { get; set; }
        public Product.Product? Product { get; set; }
        public bool IsDeleted { get; private set; }
        internal OrderDetail( int orderId, decimal price, int ?productId = null)
        {
            IsDeleted = false;
           OrderId = orderId;
            ProductId = productId;
            Price = price;
   
        }
        public OrderDetail()
        {
            
        }

        public void SoftRemove()
        {
            IsDeleted = true;
                }
    }
}
