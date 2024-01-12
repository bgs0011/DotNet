using AutoMapper;
using DotNet.Core.DTOs;
using DotNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotNet.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();

            CreateMap<UserDto, User>();
            CreateMap<ArticleDto, Article>();
            CreateMap<CommentDto, Comment>();
        }
    }
}
