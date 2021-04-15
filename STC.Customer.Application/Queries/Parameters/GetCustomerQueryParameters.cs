using System;
using STC.Shared.Cqrs.Query;

namespace STC.Customer.Application.Queries.Parameters
{
    public class GetCustomerQueryParameters : IQueryParameters
    {
        public GetCustomerQueryParameters(
               Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; set; }
    }
}
