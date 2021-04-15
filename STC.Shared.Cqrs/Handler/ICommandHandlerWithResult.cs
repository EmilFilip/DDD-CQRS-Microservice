using System.Threading;
using System.Threading.Tasks;
using STC.Shared.Cqrs.Command;

namespace STC.Shared.Cqrs.Handler
{
    public interface ICommandHandlerWithResult<in TCommand, TResult>
        where TCommand : ICommand
        where TResult : ICommandResult
    {
        Task<TResult> HandleAsync(
            TCommand command,
            CancellationToken ct = default(CancellationToken));
    }
}
