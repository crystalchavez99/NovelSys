﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelSys.Api.Filters;
using NovelSys.Application.Services.Authentication;
using NovelSys.Contracts.Authentication;

namespace NovelSys.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    //[ErrorHandlingFilter]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
            var response = new AuthenticationResponse(
                 authResult.User.Id, 
                authResult.User.FirstName, 
                authResult.User.LastName, 
                authResult.User.Email, 
                authResult.Token);
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(request.Email, request.Password);
            var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName, 
                authResult.User.LastName, 
                authResult.User.Email, 
                authResult.Token);
            return Ok(response);
        }
    }
}
