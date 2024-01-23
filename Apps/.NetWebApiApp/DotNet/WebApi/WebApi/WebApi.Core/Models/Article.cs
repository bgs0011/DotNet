using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebApi.Core.Models
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string ArticleContent { get; set; }
        public int Like { get; set; }

        //public int ArticleId { get; set; } //primary key
        public Publisher Publisher { get; set; } // Publisher ile one to many relationship oldugunu tanımlıyor.
        public int PublisherId { get; set; } //foregin key

        public ICollection<Comment>? Comment { get; set; }
    }
}

