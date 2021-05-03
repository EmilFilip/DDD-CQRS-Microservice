using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using STC.Authentication.Application.RepositoryContracts;

namespace STC.Authentication.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {

        private IDictionary<string, string> _users;

        public LoginRepository()
        {
            _users = new Dictionary<string, string>
                {
                    { "user1", "password1" },
                    { "user2", "password2" }
                };
        }

        public async Task<bool> AuthenticateUserAsync(
            string userName,
            string password,
            CancellationToken cancellationToken = default)
        {
            return _users.Any(u => u.Key == userName && u.Value == password);

        }
    }
}
