using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using EShopManagement.Infrastructure.Logging;
using EShopManagement.Infrastructure.EF;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Shared.Queries;

namespace EShopManagement.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSQLDB(configuration);
            services.AddQueries();

            services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

            return services;
        }
    }
}
