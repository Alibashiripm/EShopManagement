using EShopManagement.Domain.Entities.User;
using EShopManagement.Domain.ValueObjects.User;

namespace EShopManagement.Domain.Factories.User
{
    public class UserPremiumFactory : IUserPremiumFactory
    {
        public UserPremium Create(  int userId, PremiumRangeDate rangeDate)
        => new(userId, rangeDate);
    }
}
