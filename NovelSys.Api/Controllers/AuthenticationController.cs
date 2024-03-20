using MediatR;
using Microsoft.AspNetCore.Mvc;
using NovelSys.Contracts.Authentication;
using NovelSys.Domain.Common.Errors;
using ErrorOr;
using NovelSys.Application.Authentication.Commands.Register;
using NovelSys.Application.Authentication.Queries.Login;
using MapsterMapper;
using NovelSys.Application.Authentication.Common;
using Microsoft.AspNetCore.Authorization;

namespace NovelSys.Api.Controllers;

 [Route("api/auth")]
    [AllowAnonymous]
//[ErrorHandlingFilter]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}
