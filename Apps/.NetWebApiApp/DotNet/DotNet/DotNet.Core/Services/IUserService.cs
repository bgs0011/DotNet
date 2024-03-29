﻿using DotNet.Core.DTOs;
using DotNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Core.Services
{
    public interface IUserService : IService<User>
    {
        string GeneratePasswordHash(string userName, string password);
        UserDto FindUser(string userName, string password);
        AuthResponseDto Login(AuthRequestDto request);
    }
}
