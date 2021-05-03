using System;

namespace STC.Customer.Application.Events
{
    public interface CustomerDeleted
    {
        public Guid CustomerId { get; }
        public DateTime DeletedAt { get; }
    }
}
