namespace STC.Shared.Infrastructure.Authentication
{
    public interface IJwtAuthenticationManager
    {
        AccessToken GetToken(string username);
    }
}
