using ErrorOr;
using MediatR;
using NovelSys.Application.Authentication.Common;


namespace NovelSys.Application.Authentication.Commands.Register
{

    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
