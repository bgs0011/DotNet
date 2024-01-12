using DotNet.API.Abstraction;
using DotNet.Core.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotNet.API.Concrete
{
    public class JwtAuthenticationManagercs : IJwtAuthenticationManager
    {
        public readonly string _tokenKey;
        public JwtAuthenticationManagercs(string tokenKey) { 
            _tokenKey = tokenKey;
        }
        public AuthResponseDto Authenticate(string username, string password)
        {
            AuthResponseDto authResponseDto= new AuthResponseDto();

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_tokenKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddHours(1),
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                    SigningCredentials = new SigningCredentials( 
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                authResponseDto.Token = tokenHandler.WriteToken(token);
                return authResponseDto;
            }
            catch(Exception ex)
            {
                return authResponseDto;
            }


        }
    }
}
