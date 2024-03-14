using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelSys.Api.Filters;
using NovelSys.Application.Services.Authentication;
using NovelSys.Application.Services.Authentication.Commands;
using NovelSys.Contracts.Authentication;

namespace NovelSys.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    //[ErrorHandlingFilter]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;

        public AuthenticationController(IAuthenticationCommandService authenticationService, IAuthenticationQueryService authenticationQueryService)
        {
            _authenticationCommandService = authenticationService;
            _authenticationQueryService = authenticationQueryService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationCommandService.Register(request.FirstName, request.LastName, request.Email, request.Password);
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
            var authResult = _authenticationQueryService.Login(request.Email, request.Password);
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
