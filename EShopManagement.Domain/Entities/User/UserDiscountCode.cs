using EShopManagement.Shared.Abstractions.Domain;

namespace EShopManagement.Domain.Entities.User
{
    public class UserDiscountCode : AggregateRoot<int>
    { 
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string DiscountCode { get; set; }
    }
}
