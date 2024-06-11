using Microsoft.Extensions.DependencyInjection;
using EShopManagement.Shared.Commands;
using System.Reflection;
using EShopManagement.Domain.Factories.Blog;
using EShopManagement.Domain.Factories.Blog;
using EShopManagement.Domain.Factories.Order;
using EShopManagement.Domain.Factories.Product;
using EShopManagement.Domain.Factories.User;
using EShopManagement.Application.Mapper;

namespace EShopManagement.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<IBlogCommentFactory, BlogCommentFactory>();
            services.AddSingleton<IBlogFactory, BlogFactory>();
            services.AddSingleton<IDiscountFactory, DiscountFactory>();
            services.AddSingleton<IOrderFactory, OrderFactory>();
            services.AddSingleton<IOrderDetailFactory, OrderDetailFactory>();
            services.AddSingleton<IProductFactory, ProductFactory>();
            services.AddSingleton<IProductCategoryFactory, ProductCategoryFactory>();
            services.AddSingleton<IProductCommentFactory, ProductCommentFactory>();
            services.AddSingleton<IUserFactory, UserFactory>();
            services.AddSingleton<IUserPremiumFactory, UserPremiumFactory>();
            services.AddSingleton<IUserRoleFactory, RoleFactory>();
            services.AddAutoMapper(typeof(MapperProfile));

            return services;
        }
    }
}
