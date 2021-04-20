using System;
using STC.Shared.Cqrs.Command;

namespace STC.Customer.Application.Commands.Parameters
{
    public class UpdateCustomerCommandParameters : ICommand
    {
        public UpdateCustomerCommandParameters(
           Guid customerId,
           int age)
        {
            CustomerId = customerId;
            Age = age;
        }

        public Guid CustomerId { get; set; }
        public int Age { get; set; }
    }
}
