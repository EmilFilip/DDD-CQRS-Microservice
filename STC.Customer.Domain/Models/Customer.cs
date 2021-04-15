using System;

namespace STC.Customer.Domain.Models
{
    public class Customer
    {
        public Customer(
            Guid customerId,
            int age)
        {
            CustomerId = customerId;
            Age = age;
        }

        public static Customer CreateNew(int age)
        {
            return new Customer(
                customerId: Guid.NewGuid(),
                age: age);
        }

        public void Update(int age)
        {
            Age = age;
        }

        public Guid CustomerId { get; set; }
        public int Age { get; set; }
    }
}
