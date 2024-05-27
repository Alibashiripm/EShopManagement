using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Shared.Abstractions.Commands;


namespace EShopManagement.Application.Commands.BLog
{
    public record UpdateBLog(AdminBlogDto BlogDto) : ICommand;
}
