using System;
using System.Threading.Tasks;
using STC.Customer.Application.Commands.Parameters;
using STC.Customer.Application.Events;
using STC.Customer.Application.RepositoryContracts;
using STC.Shared.Cqrs.Handler;
using STC.Shared.Infrastructure.ServiceBus;

namespace STC.Customer.Application.Commands.Handlers
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommandParameters>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IServiceBus _serviceBus;

        public UpdateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            IServiceBus serviceBus)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _serviceBus = serviceBus ?? throw new ArgumentNullException(nameof(serviceBus));
        }

        public async Task HandleAsync(UpdateCustomerCommandParameters command)
        {
            await _customerRepository
                .UpdateCustomerAsync(command.CustomerId, command.Age);

            await _serviceBus.PublishAsync<CustomerUpdated>(
                    new
                    {
                        CustomerId = command.CustomerId,
                        UpdatedAt = DateTime.UtcNow
                    });

            await _serviceBus.SendAsync<CustomerUpdated>(
                new
                {
                    CustomerId = command.CustomerId,
                    UpdatedAt = DateTime.UtcNow
                },
                "CustomerService");
        }
    }
}
