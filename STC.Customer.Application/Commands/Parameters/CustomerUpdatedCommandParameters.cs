using System;
using STC.Shared.Cqrs.Command;

namespace STC.Customer.Application.Commands.Parameters
{
    public class CustomerUpdatedCommandParameters : ICommand
    {
        public CustomerUpdatedCommandParameters(
            Guid customerId,
            bool updated)
        {
            CustomerId = customerId;
            Updated = updated;
        }

        public Guid CustomerId { get; set; }
        public bool Updated { get; set; }
    }
}
