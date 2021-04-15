using System.Threading.Tasks;
using STC.Shared.Cqrs.Command;

namespace STC.Shared.Cqrs.Handler
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
