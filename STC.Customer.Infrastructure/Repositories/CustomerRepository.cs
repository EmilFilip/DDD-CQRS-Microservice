using System;
using System.Threading;
using System.Threading.Tasks;
using STC.Customer.Application.RepositoryContracts;
using STC.Customer.Domain.Models;

namespace STC.Customer.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<Domain.Models.Customer> GetCustomerAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomerAsync(Guid customerId, int age, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
