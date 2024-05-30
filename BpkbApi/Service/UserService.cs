using System;
using BpkbApi.Models;
using BpkbApi.Repositories;
using BCrypt.Net;
using BpkbApi.Repositories;
using BpkbApi.Services;

namespace UserProfileApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<MsUser> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null;
            }
            return user;
        }

        public async Task RegisterAsync(string username, string password)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new MsUser
            {
                UserName = username,
                Password = passwordHash,
                IsActive = true
            };
            await _userRepository.AddUserAsync(user);
        }
    }
}

