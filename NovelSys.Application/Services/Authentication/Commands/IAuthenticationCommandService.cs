using NovelSys.Application.Services.Authentication.Common;
using NovelSys.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSys.Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        AuthenticationResult Register(string FirstName,
        string LastName,
        string Email,
        string Password);

        AuthenticationResult Login(
        string Email,
        string Password);
    }
}
