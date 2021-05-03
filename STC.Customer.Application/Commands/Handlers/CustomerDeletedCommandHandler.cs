using System;
using System.Threading.Tasks;
using STC.Customer.Application.Commands.Parameters;
using STC.Customer.Application.RepositoryContracts;
using STC.Shared.Cqrs.Handler;

namespace STC.Customer.Application.Commands.Handlers
{
    public class CustomerDeletedCommandHandler : ICommandHandler<CustomerDeletedCommandParameters>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerDeletedCommandHandler(
            ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task HandleAsync(CustomerDeletedCommandParameters command)
        {
            await _customerRepository
                .UpdateCustomerDeletedAsync(
                    customerId: command.CustomerId,
                    deletedAt: command.DeletedAt);
        }
    }
}
