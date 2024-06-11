
using EShopManagement.Shared.Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace EShopManagement.Shared.Commands
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();

            // Scan and register all ICommandHandler implementations
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }

}
