using System.Threading;
using System.Threading.Tasks;

namespace STC.Authentication.Application.RepositoryContracts
{
    public interface ILoginRepository
    {
        Task<bool> AuthenticateUserAsync(
            string userName,
            string password,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
