using NovelSys.Domain.Entities;

namespace NovelSys.Application.Authentication.Common
{
    public record AuthenticationResult(User User, string Token);
}
