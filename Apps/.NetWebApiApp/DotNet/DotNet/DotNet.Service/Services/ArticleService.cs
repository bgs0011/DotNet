using DotNet.Core.Models;
using DotNet.Core.Repositories;
using DotNet.Core.Services;
using DotNet.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Service.Services
{
    public class ArticleService : Service<Article>, IArticleService
    {
        public ArticleService(IGenericRepository<Article> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
