using NovelSys.Application.Common.Errors;
using NovelSys.Application.Common.Interfaces.Authentication;
using NovelSys.Application.Common.Interfaces.Persistence;
using NovelSys.Application.Services.Authentication.Common;
using NovelSys.Domain.Entities;


namespace NovelSys.Application.Services.Authentication.Commands
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Register(string firstName,
        string lastName,
        string email,
        string password)
        {
            // if user exists
            if (_userRepository.GetUserByEmail(email) != null)
            {
                //throw new Exception("User with given email already exists.");
                throw new DuplicateEmailException();
            }

            // create user (uniq id)
            var user = new User { FirstName = firstName, LastName = lastName, Email = email, Password = password };

            _userRepository.Add(user);

            // create jwt token 
            // Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                /*user.Id, 
                firstName, 
                lastName, 
                email, */
                user,
                token);
        }

        public AuthenticationResult Login(
        string email,
        string password)
        {
            // check if user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email does not exist");
            }

            // check if password is correct
            if (user.Password != password)
            {
                throw new Exception("Invalid password");
            }

            // create jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                /*user.Id, 
                firstName, 
                lastName, 
                email, */
                user,
                token);
        }
    }
}
