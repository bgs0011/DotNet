using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Core.DTOs
{
    public class ArticleDto : BaseDto
    {
        public string Title { get; set; }
        public string ArticleContent { get; set; }
        public int Like { get; set; }
    }
}
