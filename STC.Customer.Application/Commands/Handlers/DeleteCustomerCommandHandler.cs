using System;
using System.Threading.Tasks;
using STC.Customer.Application.Commands.Parameters;
using STC.Customer.Application.Events;
using STC.Customer.Application.RepositoryContracts;
using STC.Shared.Cqrs.Handler;
using STC.Shared.Infrastructure.ServiceBus;

namespace STC.Customer.Application.Commands.Handlers
{
    public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommandParameters>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IServiceBus _serviceBus;

        public DeleteCustomerCommandHandler(
            ICustomerRepository customerRepository,
            IServiceBus serviceBus)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _serviceBus = serviceBus ?? throw new ArgumentNullException(nameof(serviceBus));
        }

        public async Task HandleAsync(DeleteCustomerCommandParameters command)
        {
            await _customerRepository
                .DeleteCustomerAsync(command.CustomerId);

            await _serviceBus.PublishAsync<CustomerDeleted>(
                    new
                    {
                        CustomerId = command.CustomerId,
                        DeletedAt = DateTime.UtcNow
                    });
        }
    }
}
