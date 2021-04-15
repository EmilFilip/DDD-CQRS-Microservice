using System;
using STC.Shared.Cqrs.Query;

namespace STC.Customer.Application.Queries.Results
{
    public class GetCustomerQueryResult : IQueryResult
    {
        public GetCustomerQueryResult(
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
