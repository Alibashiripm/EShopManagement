using EShopManagement.Application.DTOs.Blog.Admin;
using EShopManagement.Shared.Abstractions.Commands;
using System.ComponentModel.Design;

namespace EShopManagement.Application.Commands.BlogComment
{
    public record ConfirmComment(int commentId) : ICommand;
}
