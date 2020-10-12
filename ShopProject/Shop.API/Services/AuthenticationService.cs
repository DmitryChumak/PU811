using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.API.Domain.Models;
using Shop.API.Domain.Services;
using Shop.API.Domain.Services.Communication;
using Shop.API.Helpers;

namespace Shop.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppSettings appSettings;

        User user;
        public AuthenticationService(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
            user  = new User
            {
                Name = "Serg",
                Lastname = "Yarosh",
                Login = "admin",
                Password = "admin"
            };
        }
        public async Task<UserResponse> AuthenticateAsync(string login, string password)
        {
            if (login == user.Login && password == user.Password)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Role, "admin")
                    }),
                    Expires = DateTime.Now.AddMinutes(appSettings.TokenExpires),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                user.Password = null;

                return new UserResponse(user);
            }
            else 
                return new UserResponse("Error");
        }
    }
}