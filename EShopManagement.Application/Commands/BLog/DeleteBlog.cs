
using EShopManagement.Shared.Abstractions.Commands;

namespace EShopManagement.Application.Commands.BLog
{
    public record DeleteBlog(int Blogid) : ICommand;
}
