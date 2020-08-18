using GoalTracker.Domain.User;
using GoalTracker.Models.Exceptions;
using GoalTracker.Repository.User_Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GoalTracker.Services.User_Service
{
    public class UserService : IUserService
    {
        private IUserRepository<User> userRepository;
        public IConfiguration _configuration;

        public UserService(IUserRepository<User> userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task SignUp(User user)
        {
            await userRepository.Insert(user);
        }

        public async Task<User> UserCredentialsByEmail(string email)
        {
            return await userRepository.Get(email);
        }

        public async Task<string> AuthenticationToken(string email, string password)
        {
            var userCredentials = await UserCredentialsByEmail(email);

            UserCredentialValidations(password, userCredentials);

            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim("full_name", userCredentials.FirstName + " " + userCredentials.LastName)
                   };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(90),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private void UserCredentialValidations(string passwordProvided, User user)
        {
            if (user == null)
                throw new BaseApiException(System.Net.HttpStatusCode.NotFound, "User not found");

            if (user.Password != PasswordHash(passwordProvided))
                throw new BaseApiException(System.Net.HttpStatusCode.Unauthorized, "Wrong email or password provided");
        }

        public string PasswordHash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;

            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
                hashBytes = algorithm.ComputeHash(bytes);

            return Convert.ToBase64String(hashBytes);
        }

        public async Task UpdateMyProfile()
        {
            await userRepository.UpdateMyProfile();
        }
    }
}