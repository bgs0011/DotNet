using DotNet.Core.DTOs;

namespace DotNet.API.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        AuthResponseDto Authenticate(string username, string password);
    }
}
