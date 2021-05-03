using STC.Shared.Cqrs.Query;

namespace STC.Authentication.Application.Queries.Results
{
    public class GetLoginQueryResult : IQueryResult
    {
        public GetLoginQueryResult(string token)
        {
            Token = token;
        }


        public string Token { get; private set; }
    }
}
