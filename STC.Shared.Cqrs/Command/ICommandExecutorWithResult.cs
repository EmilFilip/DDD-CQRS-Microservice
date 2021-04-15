using System.Threading;
using System.Threading.Tasks;

namespace STC.Shared.Cqrs.Command
{
    public interface ICommandExecutorWithResult
    {
        Task<TResult> ExecuteAsync<TCommand, TResult>(
            TCommand command,
            CancellationToken ct = default(CancellationToken))
            where TCommand : ICommand
            where TResult : ICommandResult;
    }
}
