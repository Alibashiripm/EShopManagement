using EShopManagement.Domain;
using EShopManagement.Domain.ValueObjects.Order;


namespace EShopManagement.Domain.Factories.Order
{
    public interface IOrderFactory
    {
        Entities.Order.Order Create(decimal orderSum, bool isFinaly, OrderCreateDate createDate, int userId);
    }
}
