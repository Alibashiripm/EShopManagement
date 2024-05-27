using EShopManagement.Application.DTOs.Blog.Client;
using EShopManagement.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.BlogComment
{
    public record LeaveComment(ClientBlogLeaveCommentDto CommentDto) : ICommand;
}
