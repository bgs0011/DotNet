﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Services.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; } = "dotnet_panel_key_value_here_secret";
        public int RefreshTokenTTL { get; set; }
    }
}
