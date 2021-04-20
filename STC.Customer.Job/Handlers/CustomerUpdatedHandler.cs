using System;
using System.Threading.Tasks;
using MassTransit;
using STC.Customer.Application.Commands.Parameters;
using STC.Customer.Application.Events;
using STC.Shared.Cqrs.Command;

namespace STC.Customer.Job.Handlers
{
    public class CustomerUpdatedHandler : IConsumer<CustomerUpdated>
    {
        private readonly ICommandExecutor _commandExecutor;

        public CustomerUpdatedHandler(
           ICommandExecutor commandExecutor)
            {
                _commandExecutor = commandExecutor ?? throw new ArgumentNullException(nameof(commandExecutor));
            }

        public async Task Consume(ConsumeContext<CustomerUpdated> context)
        {
            await _commandExecutor.ExecuteAsync(
                new CustomerUpdatedCommandParameters(
                    customerId: context.Message.CustomerId,
                    updated: true));
        }
    }
}
