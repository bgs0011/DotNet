using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Core.DTOs;
using WebApi.Core.Models;
using WebApi.Core.Services;
using WebApi.Services.Services;

namespace WebApi.Api.Controllers
{
    public class ArticleController : CustomBaseController
    {
        private IMapper _mapper;
        private readonly IArticleService _articleService;
        public ArticleController(IMapper mapper, IArticleService articleService)
        {
            _mapper = mapper;
            _articleService = articleService;
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
        public async Task<IActionResult> Write(ArticleDto articleDto)
        {

            var article = await _articleService.AddAsync(new Article
            {
                Id = articleDto.Id,
                ArticleContent = articleDto.ArticleContent,
                Publisher = ,
                PublisherId = publisher.Id,

            });

            //var article = await _articleService.AddAsync(_mapper.Map<Article>(articleDto));
            var articleDtos = _mapper.Map<ArticleDto>(article);
            return CreateActionResult(GlobalResultDto<ArticleDto>.Success(201, articleDtos));
        }
        */
        /*
        
        [HttpPost("Write")]
        public async Task<IActionResult> Write(AuthRequestDto authDto)
        {
            var publisher = _publisherService.SignUp(authDto);
            var publisherDto = _mapper.Map<PublisherDto>(publisher);
            return CreateActionResult(GlobalResultDto<PublisherDto>.Success(201, publisherDto));
        }
        [HttpPost("Stories")]
        public IActionResult Stories(AuthRequestDto authDto)
        {
            var result = _publisherService.Login(authDto);
            if (result.Publisher != null)
                return CreateActionResult(GlobalResultDto<AuthResponseDto>.Success(200, result));
            else
                return CreateActionResult(GlobalResultDto<AuthResponseDto>.Success(401, result));
        }
        */
    }
}
