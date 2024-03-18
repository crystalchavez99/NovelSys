using MediatR;
using Microsoft.AspNetCore.Mvc;
using NovelSys.Application.Services.Authentication;
using NovelSys.Application.Services.Authentication.Commands;
using NovelSys.Application.Services.Authentication.Common;
using NovelSys.Contracts.Authentication;
using NovelSys.Domain.Common.Errors;
using ErrorOr;
using NovelSys.Application.Authentication.Commands.Register;
using NovelSys.Application.Authentication.Queries.Login;

namespace NovelSys.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    //[ErrorHandlingFilter]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);
           // ErrorOr<AuthenticationResult> registerResult = _authenticationCommandService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            return registerResult.Match(
                registerResult => Ok(MapAuthResult(registerResult)),
                errors => Problem(errors));

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
        public async Task<IActionResult> Login(LoginRequest request)
        {

            var query = new LoginQuery(request.Email,
                request.Password);
            var loginResult = await _mediator.Send(query);

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
