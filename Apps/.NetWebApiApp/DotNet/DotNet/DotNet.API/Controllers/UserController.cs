using AutoMapper;
using DotNet.Core.DTOs;
using DotNet.Core.Models;
using DotNet.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.API.Controllers
{
    public class UserController : CustomBaseController
    {
        private IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllAsync();
            var usersDto = _mapper.Map<List<UserDto>>(users.ToList());
            return CreateActionResult(GlobalResultDto<List<UserDto>>.Success(200, usersDto));
        }

        [HttpGet("{id}")]
        //Get api/Team/3
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(GlobalResultDto<UserDto>.Success(200, userDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            await _userService.UpdateAsync(_mapper.Map<User>(userDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _userService.GetById(id);
            await _userService.RemoveAsync(user);

            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpPost("Login")]
        public IActionResult Login(AuthRequestDto authDto)
        {
            var result = _userService.Login(authDto);
            if (result.User != null)
                return CreateActionResult(GlobalResultDto<AuthResponseDto>.Success(200, result));
            else
                return CreateActionResult(GlobalResultDto<AuthResponseDto>.Success(401, result));
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> SignupAsync(AuthRequestDto authDto)
        {
            var passwordHash = _userService.GeneratePasswordHash(authDto.UserName,authDto.Password);

            var user = await _userService.AddAsync(new User
            {
                UserName = authDto.UserName,
                Email = authDto.Email,
                Password = passwordHash

            });
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(GlobalResultDto<UserDto>.Success(201, userDto));
        }
    }
}
