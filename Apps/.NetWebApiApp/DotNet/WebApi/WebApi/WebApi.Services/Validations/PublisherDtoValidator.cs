using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs;

namespace WebApi.Services.Validations
{
    public class PublisherDtoValidator : AbstractValidator<PublisherDto>
    {
        public PublisherDtoValidator()
        {
            RuleFor(x => x.PublisherName).NotNull().WithMessage("Kullanıcı adı null olamaz.")
                .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                .MaximumLength(200).WithMessage("Kullanıcı adı en fazla 200 karakter olabilir.");

            RuleFor(x => x.Email).NotNull().WithMessage("Email null olamaz.")
                .NotEmpty().WithMessage("Email boş olamaz.")
                .MaximumLength(250).WithMessage("Email en fazla 250 karakter olabilir.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
        }
    }
}
