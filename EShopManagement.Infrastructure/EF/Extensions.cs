using EShopManagement.Application.Services;
using EShopManagement.Domain.Entities.Blog;
using EShopManagement.Domain.Entities.Order;
using EShopManagement.Domain.Entities.Product;
using EShopManagement.Domain.Entities.User;
using EShopManagement.Domain.Repositories;
using EShopManagement.Infrastructure.EF.Contexts;
using EShopManagement.Infrastructure.EF.Options;
using EShopManagement.Infrastructure.EF.Repositories;
using EShopManagement.Infrastructure.EF.Services;
using EShopManagement.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 
namespace EShopManagement.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGenericRepository<User,int>, UserRepository>();
            services.AddScoped<IGenericRepository<BlogComment,int>, BlogCommentRepository>();
            services.AddScoped<IGenericRepository<Blog,int>, BlogRepository>();
            services.AddScoped<IGenericRepository<Discount,int>, DiscountRepository>();
            services.AddScoped<IGenericRepository<OrderDetail,int>, OrderDetailRepository>();
            services.AddScoped<IGenericRepository<Order,int>, OrderRepository>();
            services.AddScoped<IGenericRepository<ProductCategory,int>, ProductCategoryRepository>();
            services.AddScoped<IGenericRepository<ProductComment,int>, ProductCommentRepository>();
            services.AddScoped<IGenericRepository<Product,int>, ProductRepository>();
            services.AddScoped<IGenericRepository<Role,int>, RoleRepository>();

            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
     
  
            var options = configuration.GetOptions<DataBaseOptions>("DataBaseConnectionString");
            services.AddDbContext<ReadDbContext>(ctx =>
            ctx.UseSqlServer(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
