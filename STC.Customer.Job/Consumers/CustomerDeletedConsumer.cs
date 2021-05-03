using System;
using System.Threading.Tasks;
using MassTransit;
using STC.Customer.Application.Commands.Parameters;
using STC.Customer.Application.Events;
using STC.Shared.Cqrs.Command;

namespace STC.Customer.Job.Consumers
{
    public class CustomerDeletedConsumer : IConsumer<CustomerDeleted>
    {
        private readonly ICommandExecutor _commandExecutor;

        public CustomerDeletedConsumer(
           ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor ?? throw new ArgumentNullException(nameof(commandExecutor));
        }

        public async Task Consume(ConsumeContext<CustomerDeleted> context)
        {
            await _commandExecutor.ExecuteAsync(
                new CustomerDeletedCommandParameters(
                    customerId: context.Message.CustomerId,
                    deletedAt: context.Message.DeletedAt));
        }
    }
}
