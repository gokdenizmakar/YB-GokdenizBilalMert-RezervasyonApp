using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Models;

namespace YB.Business.Validator
{
    public class GuestValidator : AbstractValidator<Guest>
    {
        public GuestValidator()
        {
            RuleFor(g => g.FirstName).NotEmpty().WithMessage("Ad  boş geçilemez.")
                .MinimumLength(5).WithMessage("Ad  5 minimum karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Ad maximum 50 karakter olabilir.")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen sadece harf girişi yapınız.");
            RuleFor(g => g.LastName).NotEmpty().WithMessage("Soyad boş geçilemez.")
               .MinimumLength(5).WithMessage("Soyad  5 minimum karakter olmalıdır.")
               .MaximumLength(50).WithMessage("Soyad maximum 50 karakter olabilir.")
               .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen sadece harf girişi yapınız.");

            RuleFor(h => h.Address).NotEmpty().WithMessage("Adres alanı boş geçilemez.")
                .MaximumLength(255).WithMessage("Adres alanı maximum 255 karakter olabilir.");

            RuleFor(h => h.Phone).NotEmpty().WithMessage("Telefon numarası alanı boş geçilemez.")
                .Length(11).WithMessage("Otel adı maximum 50 karakter olabilir.");

            RuleFor(h => h.Email)
                 .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi formatı.");


        }
    }
}
