using System;
using System.Threading.Tasks;
using STC.Customer.Application.Commands.Parameters;
using STC.Customer.Application.RepositoryContracts;
using STC.Shared.Cqrs.Handler;

namespace STC.Customer.Application.Commands.Handlers
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommandParameters>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(
            ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task HandleAsync(UpdateCustomerCommandParameters command)
        {
            await _customerRepository
                .UpdateCustomerAsync(command.CustomerId, command.Age);
        }
    }
}
