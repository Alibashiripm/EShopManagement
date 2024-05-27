using EShopManagement.Shared.Abstractions.Domain;

namespace EShopManagement.Domain.Entities.Order
{
    public class OrderDetail : AggregateRoot<int>
    {

        public int Id { get;private set; }
        public int OrderId { get;}
        public int ProductId { get;  }
        public decimal Price { get; }
        public Order Order { get; set; }
        public Product.Product Product { get; set; }
        public bool IsDeleted { get; private set; }
        internal OrderDetail( int orderId, int productId, decimal price)
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
