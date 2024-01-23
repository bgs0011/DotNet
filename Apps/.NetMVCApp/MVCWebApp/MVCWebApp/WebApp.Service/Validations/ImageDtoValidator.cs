using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.DTOs;

namespace WebApp.Service.Validations
{
    public class ImageDtoValidator : AbstractValidator<ImageDto>
    {
        public ImageDtoValidator()
        {
            RuleFor(x => x.FileName).NotNull().WithMessage("FileName null olamaz.")
                .NotEmpty().WithMessage("FileName boş olamaz.")
                .MaximumLength(100).WithMessage("FileName en fazla 100 karakter olabilir.");

            RuleFor(x => x.FileType).NotNull().WithMessage("FileType null olamaz.")
                .NotEmpty().WithMessage("FileType boş olamaz.")
                .MaximumLength(100).WithMessage("FileType en fazla 100 karakter olabilir.");

        }
    }
}
