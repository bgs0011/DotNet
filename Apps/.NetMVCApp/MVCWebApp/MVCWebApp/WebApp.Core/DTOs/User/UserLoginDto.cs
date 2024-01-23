using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.DTOs.User
{
    public class UserLoginDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public bool RememberMe { get; set; }

    }
}
