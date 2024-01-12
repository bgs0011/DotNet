using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs;

namespace WebApi.Services.Authorization.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        AuthResponseDto Authenticate(string publisherName, string password);
        int? ValidateJwtToken(string token);
    }
}
