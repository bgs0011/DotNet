using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.DTOs;
using WebApp.Core.Services;
using WebApp.Service.Services;

namespace WebApp.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;
        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllAsync();
            var articlesDto = _mapper.Map<List<ArticleDto>>(articles);
            return View(articlesDto);
        }
    }
}
