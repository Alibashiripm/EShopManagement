using EShopManagement.Shared.Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace EShopManagement.Shared.Commands
{
    internal sealed class InMemoryCommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

            await handler.HandleAsync(command);
        }

          public async Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command) where TCommand : class, ICommand
        {
            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();

         return  await handler.HandleAsync(command);
 
        }
    }
}
