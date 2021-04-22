using System;
using System.Threading.Tasks;
using STC.Customer.Application.Commands.Parameters;
using STC.Customer.Application.RepositoryContracts;
using STC.Shared.Cqrs.Handler;

namespace STC.Customer.Application.Commands.Handlers
{
    public class CustomerUpdatedCommandHandler : ICommandHandler<CustomerUpdatedCommandParameters>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerUpdatedCommandHandler(
            ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task HandleAsync(CustomerUpdatedCommandParameters command)
        {
            await _customerRepository
                .UpdateCustomerUpdatedAsync(
                customerId: command.CustomerId, 
                updated: command.Updated,
                updatedAt: command.UpdatedAt);
        }
    }
}
