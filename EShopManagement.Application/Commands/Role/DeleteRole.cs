using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.Role
{
    public record DeleteRole(int Id) :ICommand;
}
