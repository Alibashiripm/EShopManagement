using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.Order
{
    public record PremiumSubscriptionPayment(string Email, string Description, string CallBackUrl, int OrderId = 0) : ICommand;

}
