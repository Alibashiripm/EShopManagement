
using EShopManagement.Shared.Abstractions.Domain;
using EShopManagement.Domain.ValueObjects.Blog;
using EShopManagement.Domain.ValueObjects.Order;

namespace EShopManagement.Domain.Entities.Order
{
    public class Order : AggregateRoot<int>
    {
        public int  Id { get;private set; }
        public decimal OrderSum { get; private set; }
        public bool IsFinaly { get; private set; }
        public OrderCreateDate _createDate;
        #region relation
        public int UserId { get; set; }
        public User.User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public bool IsDeleted { get; private set; } = false;
        #endregion
        internal Order( decimal orderSum, bool isFinaly, OrderCreateDate createDate, int userId)
        {
         
            OrderSum = orderSum;
            IsFinaly = isFinaly;
            _createDate = createDate;
            UserId = userId;
       
        }
        public Order()
        {
            
        }

        public void SoftRemove()
        {
            IsDeleted = true;
        } 
        public void Finalize()
        {
            IsFinaly = true;
        } 
        public void ApplyDiscounts(decimal discountedAmount)
        {
            OrderSum -= discountedAmount;
        }
    }
}
