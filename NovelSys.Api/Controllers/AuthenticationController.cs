using MediatR;
using Microsoft.AspNetCore.Mvc;
using NovelSys.Application.Services.Authentication;
using NovelSys.Application.Services.Authentication.Commands;
using NovelSys.Application.Services.Authentication.Common;
using NovelSys.Contracts.Authentication;
using NovelSys.Domain.Common.Errors;
using ErrorOr;
namespace NovelSys.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    //[ErrorHandlingFilter]
    public class AuthenticationController : ApiController
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
            ErrorOr<AuthenticationResult> registerResult = _authenticationCommandService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            return registerResult.MatchFirst(
                registerResult => Ok(MapAuthResult(registerResult)),
                firstError => Problem(statusCode: StatusCodes.Status409Conflict, title:firstError.Description)
                );

        }

        private static AuthenticationResponse NewMethod(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
    authResult.User.Id,
    authResult.User.FirstName,
    authResult.User.LastName,
    authResult.User.Email,
    authResult.Token
    );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var loginResult = _authenticationCommandService.Login(
                request.Email,
                request.Password);

            if(loginResult.IsError && loginResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: loginResult.FirstError.Description);
            }
            return loginResult.Match(
                loginResult => Ok(MapAuthResult(loginResult)),
                errors => Problem(errors));
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
