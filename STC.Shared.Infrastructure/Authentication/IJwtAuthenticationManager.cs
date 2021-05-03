namespace STC.Shared.Infrastructure.Authentication
{
    public interface IJwtAuthenticationManager
    {
        string GetToken(string username);
    }
}
