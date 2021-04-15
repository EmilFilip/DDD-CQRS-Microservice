using System.Threading;
using System.Threading.Tasks;

namespace STC.Shared.Cqrs.Query
{

    public interface IQueryExecutor
    {
        Task<TResult> ExecuteAsync<TParameters, TResult>(TParameters parameters, CancellationToken ct = default(CancellationToken))
            where TParameters : IQueryParameters
            where TResult : IQueryResult;
    }
}
