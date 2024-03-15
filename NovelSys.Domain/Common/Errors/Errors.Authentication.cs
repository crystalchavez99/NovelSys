using ErrorOr;

namespace NovelSys.Domain.Common.Errors
{
    public static partial class Errors
    {
       public class Authentication
        {
            public static Error InvalidCredentials => Error.Conflict(
           code: "Auth.InvalidCred",
           description: "Invalid credentials"
           );
        }
    }
}
