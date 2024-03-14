using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NovelSys.Api.Filters;
using NovelSys.Application.Authentication.Commands.Register;
using NovelSys.Application.Common.Errors;
using NovelSys.Application.Services.Authentication;
using NovelSys.Application.Services.Authentication.Commands;
using NovelSys.Application.Services.Authentication.Common;
using NovelSys.Contracts.Authentication;
using FluentResults;
namespace NovelSys.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    //[ErrorHandlingFilter]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

       private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;

        public AuthenticationController(IAuthenticationCommandService authenticationService, IAuthenticationQueryService authenticationQueryService)
        {
          //  _mediator = mediator;
            _authenticationCommandService = authenticationService;
            _authenticationQueryService = authenticationQueryService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            Result<AuthenticationResult> registerResult = _authenticationCommandService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);
            if (registerResult.IsSuccess)
            {
                return Ok(MapAuthResult(registerResult.Value));
            }
            var encounterError = registerResult.Errors[0];

            if(encounterError is DuplicateEmailError)
            {
                return Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists");
            }

            return Problem();

        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationQueryService.Login(request.Email, request.Password);
            var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName, 
                authResult.User.LastName, 
                authResult.User.Email, 
                authResult.Token);
            return Ok(response);
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);
        }
    }
}
