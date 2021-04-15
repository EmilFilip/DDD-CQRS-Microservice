using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using STC.Shared.Cqrs.Handler;

namespace STC.Shared.Cqrs.Query
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly IServiceProvider _container;

        public QueryExecutor(
            IServiceProvider container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public async Task<TResult> ExecuteAsync<TParameters, TResult>(TParameters parameters, CancellationToken ct = default(CancellationToken))
            where TParameters : IQueryParameters
            where TResult : IQueryResult
        {
            ct.ThrowIfCancellationRequested();

            var handler = _container.GetRequiredService<IQueryHandler<TParameters, TResult>>();

            return await handler.HandleAsync(parameters, ct);
        }
    }
}
