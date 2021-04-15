using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using STC.Customer.Application.Commands.Parameters;
using STC.Customer.Application.RepositoryContracts;
using STC.Shared.Cqrs.Handler;

namespace STC.Customer.Application.Commands.Handlers
{
    public class CustomerCommandHandler : ICommandHandler<CustomerCommandParameters>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(
            ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task HandleAsync(CustomerCommandParameters command)
        {
            await _customerRepository
                .UpdateCustomerAsync(command.CustomerId, command.Age);
        }
    }
}
