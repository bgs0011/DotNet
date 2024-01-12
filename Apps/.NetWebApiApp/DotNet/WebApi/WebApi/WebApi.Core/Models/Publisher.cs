using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Models
{
    public class Publisher : BaseEntity
    {
        public string PublisherName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Article>? Article { get; set; }
    }
}
