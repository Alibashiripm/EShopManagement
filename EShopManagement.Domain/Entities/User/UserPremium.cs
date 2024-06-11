using EShopManagement.Shared.Abstractions.Domain;
using EShopManagement.Domain.ValueObjects.User;


namespace EShopManagement.Domain.Entities.User
{
    public class UserPremium: AggregateRoot<int>
    {
     public int UserId { get; set; }
        public PremiumRangeDate _rangeDate ;
 
        public  User User { get; set; }
        public  bool IsDeleted { get; private set; }
        public UserPremium(int userId, PremiumRangeDate rangeDate)
        {

            UserId = userId;
            _rangeDate = rangeDate;
        }
        public UserPremium()
        {

        }
    }
}
