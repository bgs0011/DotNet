using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApi.Core.DTOs;
using WebApi.Core.Models;
using WebApi.Core.Services;
using WebApi.Repository.UnitOfWorks;
using WebApi.Services.Helpers;
using WebApi.Services.Services;
using static System.Net.Mime.MediaTypeNames;

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

        [HttpPost("Write")]
        //[Authorize(Roles ="User")]
        public async Task<IActionResult> WriteArticleAsync(ArticleDto articleDto)
        {

            var publisher = LoggedInUserExtensions.GetLoggedinUser();
            Article article = await _articleService.AddAsync(new Article
            {

                ArticleContent = articleDto.ArticleContent,
                PublisherId = publisher.Id,
                Title = articleDto.Title,

            });
            await _articleService.UpdateAsync(article);
            _articleService.SetPublisherforCreatedArticle(publisher, article);
            var temparticleDto = _mapper.Map<ArticleDto>(article);
            return CreateActionResult(GlobalResultDto<ArticleDto>.Success(201, temparticleDto));

        }

    }
}
