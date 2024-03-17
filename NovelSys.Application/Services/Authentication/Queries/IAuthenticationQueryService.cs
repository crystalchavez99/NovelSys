using NovelSys.Application.Services.Authentication.Common;
using ErrorOr;


namespace NovelSys.Application.Services.Authentication
{
    public interface IAuthenticationQueryService
    {
       // AuthenticationResult Register(string FirstName, string LastName, string Email,string Password);

        ErrorOr<AuthenticationResult> Login(
        string Email,
        string Password);
    }
}
