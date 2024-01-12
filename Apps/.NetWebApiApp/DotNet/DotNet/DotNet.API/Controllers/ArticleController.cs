using AutoMapper;
using DotNet.Core.DTOs;
using DotNet.Core.Models;
using DotNet.Core.Services;
using DotNet.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.API.Controllers
{
    public class ArticleController : CustomBaseController
    {
        private IMapper _mapper;
        private readonly IArticleService _articleService;
        public ArticleController(IMapper mapper, IArticleService articleService)
        {
            _mapper = mapper;
            _articleService= articleService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var articles = await _articleService.GetAllAsync();
            var articlesDto = _mapper.Map<List<ArticleDto>>(articles.ToList());
            return CreateActionResult(GlobalResultDto<List<ArticleDto>>.Success(200, articlesDto));
        }

        [HttpGet("{id}")]
        //Get api/Team/3
        public async Task<IActionResult> GetById(int id)
        {
            var article = await _articleService.GetById(id);
            var articleDto = _mapper.Map<ArticleDto>(article);
            return CreateActionResult(GlobalResultDto<ArticleDto>.Success(200, articleDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ArticleDto articleDto)
        {
            var article = await _articleService.AddAsync(_mapper.Map<Article>(articleDto));
            var articleDtos = _mapper.Map<ArticleDto>(article);
            return CreateActionResult(GlobalResultDto<ArticleDto>.Success(201, articleDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ArticleDto articleDto)
        {
            await _articleService.UpdateAsync(_mapper.Map<Article>(articleDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var article = await _articleService.GetById(id);
            await _articleService.RemoveAsync(article);

            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        /*
        
        [HttpPost("Write")]
        public async Task<IActionResult> Write(AuthRequestDto authDto)
        {
            var user = _userService.SignUp(authDto);
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(GlobalResultDto<UserDto>.Success(201, userDto));
        }
        [HttpPost("Stories")]
        public IActionResult Stories(AuthRequestDto authDto)
        {
            var result = _userService.Login(authDto);
            if (result.User != null)
                return CreateActionResult(GlobalResultDto<AuthResponseDto>.Success(200, result));
            else
                return CreateActionResult(GlobalResultDto<AuthResponseDto>.Success(401, result));
        }
        */
    }
}
