﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSys.Contracts.Authentication
{
    public record AuthenticationResponse
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
}
