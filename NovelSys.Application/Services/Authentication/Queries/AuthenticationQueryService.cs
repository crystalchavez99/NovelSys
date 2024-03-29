﻿/*using ErrorOr;
using NovelSys.Application.Common.Errors;
using NovelSys.Application.Common.Interfaces.Authentication;
using NovelSys.Application.Common.Interfaces.Persistence;
using NovelSys.Application.Services.Authentication.Common;
using NovelSys.Domain.Common.Errors;
using NovelSys.Domain.Entities;


namespace NovelSys.Application.Services.Authentication
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        /* public AuthenticationResult Register(string firstName,
         string lastName,
         string email,
         string password)
         {
             // if user exists
             if(_userRepository.GetUserByEmail(email) != null)
             {
                 throw new Exception("User with given email already exists.");
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
                 email, 
                 user,
                 token);   
         }

        public ErrorOr<AuthenticationResult> Login(
        string email,
        string password)
        {
            // check if user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // check if password is correct
            if (user.Password != password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // create jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token); 
                }
    }
}
*/