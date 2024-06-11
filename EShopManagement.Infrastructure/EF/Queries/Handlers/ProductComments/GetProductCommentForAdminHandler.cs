using EShopManagement.Application.DTOs.Product.Admin;
using EShopManagement.Application.Queries.ProductComment;
using EShopManagement.Infrastructure.EF.Contexts;
 
using EShopManagement.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Queries.Handlers.ProductComments
{
    internal sealed class GetProductCommentForAdminHandler : IQueryHandler<GetProductCommentForAdmin, AdminProductCommentDto>
    {
        private readonly DbSet<Domain.Entities.Product.ProductComment> _productComments;


        public GetProductCommentForAdminHandler(ReadDbContext context)
        {
            _productComments = context.ProductComments;
        }
        public async Task<AdminProductCommentDto> HandleAsync(GetProductCommentForAdmin query)
        {
            var productComments = await _productComments.AsNoTracking()
                 .SingleOrDefaultAsync(c => c.Id == query.CommentId);
            return productComments.AsAdminProductCommentDto();
        }
    } 
}
