using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Services;
using EShopManagement.Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.BlogComment.Handlers
{
    internal sealed class ConfirmCommentHandler : ICommandHandler<ConfirmComment>
    {
        private readonly IBlogService _blogService;
        public ConfirmCommentHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task HandleAsync(ConfirmComment command)
        {

            await _blogService.ConfrimBlogCommentAsync(command.commentId);
        }
    }  
}
