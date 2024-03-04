using NovelSys.Domain.Entities;

namespace NovelSys.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
