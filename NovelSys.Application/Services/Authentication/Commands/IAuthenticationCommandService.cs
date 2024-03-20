using ErrorOr;
using NovelSys.Application.Authentication.Common;

namespace NovelSys.Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        ErrorOr<AuthenticationResult> Register(string FirstName,
        string LastName,
        string Email,
        string Password);

       // ErrorOr<AuthenticationResult> Login(string Email,string Password);
    }
}
