using STC.Shared.Cqrs.Query;
using STC.Shared.Infrastructure.Authentication;

namespace STC.Authentication.Application.Queries.Results
{
    public class GetLoginQueryResult : IQueryResult
    {
        public GetLoginQueryResult(AccessToken userAccessToken)
        {
            UserAccessToken = userAccessToken;
        }

        public AccessToken UserAccessToken { get; private set; }
    }
}
