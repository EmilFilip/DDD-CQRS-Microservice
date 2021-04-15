using System;

namespace STC.Customer.Application.Commands.DTOs
{
    public class CustomerApiParameters
    {
        public Guid CustomerId { get; set; }
        public int Age { get; set; }
    }
}
