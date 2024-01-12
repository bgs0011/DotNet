﻿using DotNet.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResult<T>(GlobalResultDto<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            }

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode

            };

        }
    }
}
