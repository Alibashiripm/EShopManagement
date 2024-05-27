using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.User
{
    public record DeleteUser(int UserId):ICommand;
}
