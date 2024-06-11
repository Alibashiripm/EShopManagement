using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.User
{
    public record ConfrimUserEmail(string userName, string activeCode  ):ICommand;
}
