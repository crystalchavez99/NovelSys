using ErrorOr;
using MediatR;
using NovelSys.Application.Services.Authentication.Common;


namespace NovelSys.Application.Authentication.Queries.Login
{
    public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
