using System;

namespace STC.Customer.Application.Events
{
    public interface CustomerUpdated
    {
        public Guid CustomerId { get; }
        public DateTime UpdatedAt { get; }

    }
}
