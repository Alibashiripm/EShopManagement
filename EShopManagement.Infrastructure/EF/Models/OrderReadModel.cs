using EShopManagement.Domain.Entities.User;

namespace EShopManagement.Infrastructure.EF.Models
{
    internal class OrderReadModel
    {
        public int Id { get; set; }
        public decimal OrderSum { get; set; }
        public bool IsFinaly { get; set; }
        public DateTime CreateDate;
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderDetailReadModel> OrderDetails { get; set; }
        public bool IsDeleted { get;   set; }
    }
}
