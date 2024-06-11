using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using EShopManagement.Infrastructure.Logging;
using EShopManagement.Infrastructure.EF;
using EShopManagement.Shared.Abstractions.Commands;
using EShopManagement.Shared.Queries;
using EShopManagement.Application.Services;
using EShopManagement.Infrastructure.EF.Services;
using EShopManagement.Infrastructure.Services;

namespace EShopManagement.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSQLDB(configuration);
            services.AddScoped<IEmailService, EmailService>();
            services.AddQueries();

            services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

            return services;
        }
    }
}
