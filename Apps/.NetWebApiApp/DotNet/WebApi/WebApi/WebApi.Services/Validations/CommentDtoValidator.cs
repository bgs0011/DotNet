using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs;

namespace WebApi.Services.Validations
{
    public class CommentDtoValidator : AbstractValidator<CommentDto>
    {
        public CommentDtoValidator()
        {
            RuleFor(x => x.Content).NotNull().WithMessage("İçerik null olamaz.")
                .NotEmpty().WithMessage("İçerik boş olamaz.")
                .MaximumLength(50).WithMessage("İçerik en fazla 50 karakter olabilir.");

        }
    }
}
