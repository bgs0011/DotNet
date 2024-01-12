using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs;
using WebApi.Core.Models;

namespace WebApi.Services.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();

            CreateMap<PublisherDto, Publisher>();
            CreateMap<ArticleDto, Article>();
            CreateMap<CommentDto, Comment>();
        }
    }
}
