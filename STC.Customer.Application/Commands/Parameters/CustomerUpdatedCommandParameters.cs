using System;
using STC.Shared.Cqrs.Command;

namespace STC.Customer.Application.Commands.Parameters
{
    public class CustomerUpdatedCommandParameters : ICommand
    {
        public CustomerUpdatedCommandParameters(
            Guid customerId,
            bool updated,
            DateTime updatedAt)
        {
            CustomerId = customerId;
            Updated = updated;
            UpdatedAt = updatedAt;
        }

        public Guid CustomerId { get; set; }
        public bool Updated { get; set; }
        public DateTime UpdatedAt { get; }
    }
}
