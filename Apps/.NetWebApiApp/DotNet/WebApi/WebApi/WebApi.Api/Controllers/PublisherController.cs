using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.DTOs;
using WebApi.Core.Models;
using WebApi.Core.Services;

namespace WebApi.Api.Controllers
{
    public class PublisherController : CustomBaseController
    {
        private IMapper _mapper;
        private readonly IPublisherService _publisherService;

        public PublisherController(IMapper mapper, IPublisherService publisherService)
        {
            _mapper = mapper;
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var publishers = await _publisherService.GetAllAsync();
            var publishersDto = _mapper.Map<List<PublisherDto>>(publishers.ToList());
            return CreateActionResult(GlobalResultDto<List<PublisherDto>>.Success(200, publishersDto));
        }

        [HttpGet("{id}")]
        //Get api/Team/3
        public async Task<IActionResult> GetById(int id)
        {
            var publisher = await _publisherService.GetById(id);
            var publisherDto = _mapper.Map<PublisherDto>(publisher);
            return CreateActionResult(GlobalResultDto<PublisherDto>.Success(200, publisherDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PublisherDto publisherDto)
        {
            await _publisherService.UpdateAsync(_mapper.Map<Publisher>(publisherDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var publisher = await _publisherService.GetById(id);
            await _publisherService.RemoveAsync(publisher);

            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpPost("Login")]
        public IActionResult Login(AuthRequestDto authDto)
        {
            var result = _publisherService.Login(authDto);
            if (result.Publisher != null)
                return CreateActionResult(GlobalResultDto<AuthResponseDto>.Success(200, result));
            else
                return CreateActionResult(GlobalResultDto<AuthResponseDto>.Success(401, result));
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> SignupAsync(AuthRequestDto authDto)
        {
            var passwordHash = _publisherService.GeneratePasswordHash(authDto.PublisherName, authDto.Password);

            var publisher = await _publisherService.AddAsync(new Publisher
            {
                PublisherName = authDto.PublisherName,
                Email = authDto.Email,
                Password = passwordHash

            });
            var publisherDto = _mapper.Map<PublisherDto>(publisher);
            return CreateActionResult(GlobalResultDto<PublisherDto>.Success(201, publisherDto));
        }

    }
}
