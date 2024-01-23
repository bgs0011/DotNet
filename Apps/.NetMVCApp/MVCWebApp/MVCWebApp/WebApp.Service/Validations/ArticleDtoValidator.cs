using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.DTOs;

namespace WebApp.Service.Validations
{
    public class ArticleDtoValidator : AbstractValidator<ArticleDto>
    {
        public ArticleDtoValidator()
        {
            RuleFor(x => x.ArticleContent).NotNull().WithMessage("Article içeriği null olamaz.")
                .NotEmpty().WithMessage("Article içeriği boş olamaz.")
                .MaximumLength(1000).WithMessage("Article içeriği en fazla 1000 karakter olabilir.");

            RuleFor(x => x.Title).NotNull().WithMessage("Başlık null olamaz.")
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

        }
    }
}
