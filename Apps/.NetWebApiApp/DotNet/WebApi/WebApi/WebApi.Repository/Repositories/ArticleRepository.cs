using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Models;
using WebApi.Core.Repositories;

namespace WebApi.Repository.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
