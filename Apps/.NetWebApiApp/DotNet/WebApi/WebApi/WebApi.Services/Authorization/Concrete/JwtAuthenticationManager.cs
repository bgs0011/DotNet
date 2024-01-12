using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs;
using WebApi.Services.Authorization.Abstraction;
using WebApi.Services.Helpers;

namespace WebApi.Services.Authorization.Concrete
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly AppSettings _appSettings;

        public JwtAuthenticationManager(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public AuthResponseDto Authenticate(string publisherName, string password)
        {
            AuthResponseDto authResponseDto = new AuthResponseDto();

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddHours(1),
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, publisherName)
                    }),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                authResponseDto.Token = tokenHandler.WriteToken(token);
                return authResponseDto;
            }
            catch (Exception ex)
            {
                return authResponseDto;
            }
        }

        public int? ValidateJwtToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var publisherId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                return publisherId;
            }
            catch
            {
                return null;
            }
        }
    }
}
