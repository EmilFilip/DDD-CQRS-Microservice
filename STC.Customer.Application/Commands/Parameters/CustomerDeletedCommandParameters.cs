using System;
using STC.Shared.Cqrs.Command;

namespace STC.Customer.Application.Commands.Parameters
{
    public class CustomerDeletedCommandParameters : ICommand
    {
        public CustomerDeletedCommandParameters(
            Guid customerId,
            DateTime deletedAt)
        {
            CustomerId = customerId;
            DeletedAt = deletedAt;
        }

        public Guid CustomerId { get; set; }
        public DateTime DeletedAt { get; }
    }
}
