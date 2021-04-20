using System;

namespace STC.Customer.Application.Commands.DTOs
{
    public class UpdateCustomerApiParameters
    {
        public Guid CustomerId { get; set; }
        public int Age { get; set; }
    }
}
