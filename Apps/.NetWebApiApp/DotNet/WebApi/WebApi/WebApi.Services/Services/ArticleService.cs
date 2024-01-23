using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs;
using WebApi.Core.Models;
using WebApi.Core.Repositories;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;
using WebApi.Repository.Repositories;

namespace WebApi.Services.Services
{
    public class ArticleService : Service<Article>, IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        private readonly IPublisherRepository _publisherRepository;

        public ArticleService(IGenericRepository<Article> repository, IUnitOfWork unitOfWork, IMapper mapper, IArticleRepository articleRepository, IPublisherRepository publisherRepository) : base(repository, unitOfWork)
        {

            _mapper = mapper;
            _articleRepository = articleRepository;
            _publisherRepository = publisherRepository;
        }
        public void SetPublisherforCreatedArticle(Publisher publisher, Article article)
        {
            var temppublisher = _publisherRepository.GetByIdAsync(publisher.Id);
            
            publisher.Article.Add(article);
            _publisherRepository.Update(publisher);
        }

    }
}
