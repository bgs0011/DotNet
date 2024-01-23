using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Models;

namespace WebApi.Core.Services
{
    public interface IArticleService : IService<Article>
    {
        void SetPublisherforCreatedArticle(Publisher publisher, Article article);
    }
}
