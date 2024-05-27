using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.Application.Commands.ProductComment.Handlers
{
    internal sealed class ConfrimProductCommentHandler : ICommandHandler<ConfrimProductComment>
    {
        private readonly IProductService productService;

        public ConfrimProductCommentHandler(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task HandleAsync(ConfrimProductComment command)
        {
            await productService.ConfrimProductCommentAsync(command.ProductCommentId);
        }
    }
}
