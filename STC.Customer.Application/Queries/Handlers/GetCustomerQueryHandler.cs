using System;
using System.Threading;
using System.Threading.Tasks;
using STC.Customer.Application.Queries.Parameters;
using STC.Customer.Application.Queries.Results;
using STC.Customer.Application.RepositoryContracts;
using STC.Shared.Cqrs.Handler;

namespace STC.Customer.Application.Queries.Handlers
{
    public class GetCustomerQueryHandler :
        IQueryHandler<GetCustomerQueryParameters, GetCustomerQueryResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerQueryHandler(
            ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<GetCustomerQueryResult> HandleAsync(
            GetCustomerQueryParameters parameters,
            CancellationToken ct = default)
        {
            var customer = await _customerRepository.GetCustomerAsync(parameters.CustomerId);

            return new GetCustomerQueryResult(
                customerId: customer.CustomerId,
                age: customer.Age);
        }
    }
}
