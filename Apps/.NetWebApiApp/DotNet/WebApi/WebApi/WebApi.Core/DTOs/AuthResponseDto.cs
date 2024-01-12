using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public PublisherDto Publisher { get; set; }
    }
}
