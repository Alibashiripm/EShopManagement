using EShopManagement.Shared.Abstractions.Domain;
using EShopManagement.Domain.ValueObjects.User;


namespace EShopManagement.Domain.Entities.User
{
    public class UserPremium: AggregateRoot<int>
    {
      
        public int PremiumId { get; private set; }
        public int UserId { get;   }
        public PremiumRangeDate _rangeDate;
        public UserPremium( int userId, PremiumRangeDate rangeDate)
        {
           
            UserId = userId;
            _rangeDate = rangeDate;
        }
        public UserPremium()
        {
            
        }

        public  User User { get; set; }
        public  bool IsDeleted { get; set; }
    }
}
