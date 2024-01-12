using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Models;
using WebApi.Core.Repositories;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;

namespace WebApi.Services.Services
{
    public class ArticleService : Service<Article>, IArticleService
    {
        public ArticleService(IGenericRepository<Article> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {

        }
    }
}
