using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WebApp.Core.Models
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string ArticleContent { get; set; }
        public int ViewCount { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? ImageId { get; set; }
        public Image Image { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }

    }
}
