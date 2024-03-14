using NovelSys.Application.Services.Authentication.Common;
using FluentResults;
using NovelSys.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSys.Application.Common.Errors;

namespace NovelSys.Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        Result<AuthenticationResult> Register(string FirstName,
        string LastName,
        string Email,
        string Password);

       AuthenticationResult Login(
        string Email,
        string Password);
    }
}
