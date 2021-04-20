using System;
using System.Threading.Tasks;
using STC.Customer.Application.Commands.Parameters;
using STC.Customer.Application.RepositoryContracts;
using STC.Shared.Cqrs.Handler;

namespace STC.Customer.Application.Commands.Handlers
{
    public class InsertCustomerCommandHandler : ICommandHandler<InsertCustomerCommandParameters>
    {
        private readonly ICustomerRepository _customerRepository;

        public InsertCustomerCommandHandler(
            ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task HandleAsync(InsertCustomerCommandParameters command)
        {
            var customer = Domain.Models.Customer.CreateNew(command.Age);

            await _customerRepository
                .InsertCustomerAsync(customer);
        }
    }
}
