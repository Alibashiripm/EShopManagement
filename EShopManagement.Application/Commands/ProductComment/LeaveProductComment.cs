using EShopManagement.Application.DTOs.Product.Client;
using EShopManagement.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.ProductComment
{
    public record LeaveProductComment(ClientLeaveProductCommentDto CommentDto) :ICommand;
}
