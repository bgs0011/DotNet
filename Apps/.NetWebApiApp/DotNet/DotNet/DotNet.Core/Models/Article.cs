using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Core.Models
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string ArticleContent { get; set; }
        public int Like { get; set; }

        //public int ArticleId { get; set; } //primary key
        public User User { get; set; } // User ile one to many relationship oldugunu tanımlıyor.
        public int UserId { get; set; } //foregin key

        public ICollection<Comment> Comment { get; set; }
    }
}
