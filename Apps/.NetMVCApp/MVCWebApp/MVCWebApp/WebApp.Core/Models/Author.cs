using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Models
{
    public class Author: BaseEntity
    {
        public string AboutAuthor { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }


    }
}
