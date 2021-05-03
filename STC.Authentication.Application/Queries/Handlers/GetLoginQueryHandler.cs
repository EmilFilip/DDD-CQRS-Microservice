using System;
using System.Threading;
using System.Threading.Tasks;
using STC.Authentication.Application.Queries.Parameters;
using STC.Authentication.Application.Queries.Results;
using STC.Authentication.Application.RepositoryContracts;
using STC.Shared.Cqrs.Handler;
using STC.Shared.Infrastructure.Authentication;

namespace STC.Authentication.Application.Queries.Handlers
{
    public class GetLoginQueryHandler :
        IQueryHandler<GetLoginQueryParameters, GetLoginQueryResult>
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public GetLoginQueryHandler(
            ILoginRepository loginRepository,
            IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _loginRepository = loginRepository ?? throw new ArgumentNullException(nameof(loginRepository));
            _jwtAuthenticationManager = jwtAuthenticationManager ?? throw new ArgumentNullException(nameof(jwtAuthenticationManager));
        }

        public async Task<GetLoginQueryResult> HandleAsync(
            GetLoginQueryParameters parameters,
            CancellationToken ct = default)
        {
            var authenticated = await _loginRepository.AuthenticateUserAsync(parameters.UserName, parameters.Password);

            if (!authenticated)
            {
                return null;
            }

            var token = _jwtAuthenticationManager.GetToken(parameters.UserName);

            return new GetLoginQueryResult(token);
        }
    }
}
