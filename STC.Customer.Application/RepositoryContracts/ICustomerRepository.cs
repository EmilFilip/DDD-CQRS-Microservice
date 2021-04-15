using System;
using System.Threading;
using System.Threading.Tasks;

namespace STC.Customer.Application.RepositoryContracts
{
    public interface ICustomerRepository
    {
        Task<Domain.Models.Customer> GetCustomerAsync(
            Guid customerId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task UpdateCustomerAsync(
            Guid customerId,
            int age,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
