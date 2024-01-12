using DotNet.Core.DTOs;

namespace DotNet.API.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        AuthResponseDto Authenticate(string userName, string password);
        int? ValidateJwtToken(string token);
    }
}
