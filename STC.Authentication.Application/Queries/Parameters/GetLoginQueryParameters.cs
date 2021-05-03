using STC.Shared.Cqrs.Query;

namespace STC.Authentication.Application.Queries.Parameters
{
    public class GetLoginQueryParameters : IQueryParameters
    {
        public GetLoginQueryParameters(
            string userName,
            string password)
        {
            UserName = userName;
            Password = password;
        }


        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}
