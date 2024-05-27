using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.Role
{
    public record UpdateRole(int Id,string Title) :ICommand;
}
