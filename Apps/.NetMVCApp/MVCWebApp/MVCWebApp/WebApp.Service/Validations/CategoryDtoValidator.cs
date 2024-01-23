using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.DTOs;

namespace WebApp.Service.Validations
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Category Name null olamaz.")
                .NotEmpty().WithMessage("Category Name boş olamaz.")
                .MaximumLength(100).WithMessage("Category Name en fazla 100 karakter olabilir.");

        }
    }
}
