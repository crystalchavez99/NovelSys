using NovelSys.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSys.Application.Services.Authentication.Common
{
    public record AuthenticationResult
   (
        /*Guid Id,
        string FirstName,
        string LastName,
        string Email,*/
        User User,
        string Token
        );
}
