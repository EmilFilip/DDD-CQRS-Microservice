using System.Threading;
using System.Threading.Tasks;
using STC.Shared.Cqrs.Query;

namespace STC.Shared.Cqrs.Handler
{
    public interface IQueryHandler<in TParameters, TResult>
        where TParameters : IQueryParameters
        where TResult : IQueryResult
    {
        Task<TResult> HandleAsync(TParameters parameters, CancellationToken ct = default(CancellationToken));
    }
}
