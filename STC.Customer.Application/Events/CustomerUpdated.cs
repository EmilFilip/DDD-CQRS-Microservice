using System;

namespace STC.Customer.Application.Events
{
    public class CustomerUpdated
    {
        public CustomerUpdated(Guid customerId)
        {
            CustomerId = customerId;
        }
        public Guid CustomerId { get; private set; }
    }
}
