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

        Task InsertCustomerAsync(
            Domain.Models.Customer customer,
            CancellationToken cancellationToken = default(CancellationToken));

        Task UpdateCustomerAsync(
            Guid customerId,
            int age,
            CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteCustomerAsync(
            Guid customerId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task UpdateCustomerUpdatedAsync(
            Guid customerId,
            bool updated,
            DateTime updatedAt,
            CancellationToken cancellationToken = default(CancellationToken));

        Task UpdateCustomerDeletedAsync(
            Guid customerId,
            DateTime deletedAt,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
