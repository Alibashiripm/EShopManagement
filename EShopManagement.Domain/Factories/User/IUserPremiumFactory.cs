using EShopManagement.Domain.Entities.User;
using EShopManagement.Domain.ValueObjects.User;

namespace EShopManagement.Domain.Factories.User
{
    public interface IUserPremiumFactory
    {
        UserPremium Create( int userId, PremiumRangeDate rangeDate);
    }
}
