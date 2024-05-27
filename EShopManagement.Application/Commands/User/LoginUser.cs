using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.User
{
    public record LoginUser(string info ,bool isPersistent, string password):ICommand;
}
