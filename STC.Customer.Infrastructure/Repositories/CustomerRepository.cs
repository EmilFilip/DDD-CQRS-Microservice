using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STC.Customer.Application.RepositoryContracts;
using STC.Customer.Infrastructure.DBContexts;

namespace STC.Customer.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerRepository(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public async Task<Domain.Models.Customer> GetCustomerAsync(
            Guid customerId, 
            CancellationToken cancellationToken = default)
        {
            var entity = await _customerDbContext
            .Customers
            .FirstOrDefaultAsync(j => j.CustomerId == customerId);

            if (entity == null)
            {
                return null;
            }

            return MapToDomain(entity);
        }

        public async Task InsertCustomerAsync(
            Domain.Models.Customer customer, 
            CancellationToken cancellationToken = default)
        {
            var entity = MapToEntity(customer);

            _customerDbContext.Customers.Add(entity);

            await _customerDbContext
                .SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCustomerAsync(
            Guid customerId, int age, 
            CancellationToken cancellationToken = default)
        {
            var entity = await _customerDbContext.Customers.FindAsync(
                keyValues: new object[] { customerId }, 
                cancellationToken: cancellationToken);

            if (entity != null)
            {
                entity.Age = age;

                _customerDbContext.Update(entity);
                await _customerDbContext.SaveChangesAsync(cancellationToken);
            }
        }

        private static Entities.Customer MapToEntity(
            Domain.Models.Customer domainCustomer)
        {
            return new Entities.Customer
            {
              CustomerId = domainCustomer.CustomerId,
              Age = domainCustomer.Age
            };
        }

        private static Domain.Models.Customer MapToDomain(
            Entities.Customer entityCustomer)
        {
            return new Domain.Models.Customer(
                customerId: entityCustomer.CustomerId,
                age: entityCustomer.Age);
        }
    }
}
