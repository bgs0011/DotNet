using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Models;

namespace WebApi.Services.Helpers
{
    public static class LoggedInUserExtensions
    {
        public static Publisher _publisher;
        public static Publisher GetLoggedinUser()
        {
            return _publisher;
        }

        public static void SetLoggedinUser(Publisher publisher)
        {
            _publisher = publisher;
        }
    }
}
