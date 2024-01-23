using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.DTOs;
using WebApp.Core.Models;
using WebApp.Core.Repositories;
using WebApp.Core.Services;
using WebApp.Core.UnitOfWorks;

namespace WebApp.Service.Services
{
    public class ArticleService : Service<Article>, IArticleService
    {

        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public ArticleService(IGenericRepository<Article> repository, IUnitOfWork unitOfWork, IArticleRepository articleRepository, IMapper mapper) : base(repository, unitOfWork){
             
        }

    }
}
