using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.DTOs
{
    public class PublisherDto : BaseDto
    {
        public string PublisherName { get; set; }
        public string Email { get; set; }
    }
}
