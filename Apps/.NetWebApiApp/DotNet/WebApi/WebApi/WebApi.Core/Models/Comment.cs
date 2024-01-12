using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Models
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        //public int CommentId { get; set; } //primary key
        public Article Article { get; set; } // Article ile one to many relationship oldugunu tanımlıyor.
        public int ArticleId { get; set; } //foregin key
    }
}
