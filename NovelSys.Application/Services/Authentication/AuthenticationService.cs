﻿using NovelSys.Application.Common.Interfaces.Authentication;
using NovelSys.Application.Common.Interfaces.Persistence;
using NovelSys.Domain.Entities;


namespace NovelSys.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
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
            if(_userRepository.GetUserByEmail(email) != null)
            {
                throw new Exception("User with given email already exists.");
            }

            // create user (uniq id)
            var user = new User { FirstName = firstName, LastName = lastName, Email = email, Password = password };

            _userRepository.Add(user);

            // create jwt token 
           // Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(user.Id,firstName, lastName);

            return new AuthenticationResult(user.Id, firstName, lastName, email, token);   
        }

        public AuthenticationResult Login(
        string email,
        string password)
        {
            return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
        }
    }
}
