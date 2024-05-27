using EShopManagement.Application.Services;
using EShopManagement.Domain.Entities.Product;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopManagement.Infrastructure.EF.Services
{
    internal sealed class ProductService : IProductService
    {

        private readonly DbSet<ProductReadModel> _products;
        private readonly DbSet<ProductComment> _productsComments;
        private readonly WriteDbContext writeDbContext;

        public ProductService(ReadDbContext readDbContext, WriteDbContext writeDbContext)
        {
            this.writeDbContext = writeDbContext;
            _products = readDbContext.Products;
            _productsComments = writeDbContext.ProductComments;
        }
        public async Task ConfrimProductCommentAsync(int CommentId)
        {
            var comment = await _productsComments.SingleOrDefaultAsync(c => c.Id == CommentId);
            comment.Confrim();
            await writeDbContext.SaveChangesAsync();

        }

        public async Task<bool> IsProductExistWithIdAsync(int BlogId)
        {

            return await _products.AnyAsync(b => b.Id == BlogId);
        }

        public async Task<bool> IsProductExistWithTitleAsync(string BlogTitle)
        {
            return await _products.AnyAsync(b => b.Title == BlogTitle);
        }
    }
}
