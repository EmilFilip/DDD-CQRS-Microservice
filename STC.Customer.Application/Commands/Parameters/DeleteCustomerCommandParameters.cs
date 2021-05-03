using System;
using STC.Shared.Cqrs.Command;

namespace STC.Customer.Application.Commands.Parameters
{
    public class DeleteCustomerCommandParameters : ICommand
    {
        public DeleteCustomerCommandParameters(
           Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; set; }
    }
}
