namespace EShopManagement.Shared.Abstractions.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        Task HandleAsync(TCommand command);
    }
    public interface ICommandHandler<TCommand, TResult> where TCommand : class, ICommand
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}
