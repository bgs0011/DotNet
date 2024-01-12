using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.DTOs
{
    public class AuthRequestDto
    {
        public string PublisherName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
