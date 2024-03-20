using Mapster;
using NovelSys.Application.Authentication.Commands.Register;
using NovelSys.Application.Authentication.Common;
using NovelSys.Application.Authentication.Queries.Login;
using NovelSys.Contracts.Authentication;

namespace NovelSys.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
