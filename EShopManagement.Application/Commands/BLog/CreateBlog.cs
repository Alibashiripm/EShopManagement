using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Shared.Abstractions.Commands;
namespace EShopManagement.Application.Commands.BLog
{
   public record CreateBlog(AdminBlogDto BlogDto) : ICommand;
}
