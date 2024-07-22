using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Models;

namespace YB.Business.Validator
{
    public class HotelValidator:AbstractValidator<Hotel>
    {
        public HotelValidator()
        {
            RuleFor(h => h.Name).NotEmpty().WithMessage("Otel adı alanı boş geçilemez.")
                .MinimumLength(5).WithMessage("Otel adı en az 5 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Otel adı maximum 50 karakter olabilir.")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen sadece harf girişi yapınız.");

            RuleFor(h => h.Address).NotEmpty().WithMessage("Adres alanı boş geçilemez.")
                .MaximumLength(255).WithMessage("Adres alanı maximum 255 karakter olabilir.");

            RuleFor(h => h.Phone).NotEmpty().WithMessage("Telefon numarası alanı boş geçilemez.")
                .Length(11).WithMessage("Otel adı maximum 50 karakter olabilir.");

            RuleFor(h => h.Email)
                 .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi formatı."); 

            RuleFor(h => h.Stars).InclusiveBetween((byte)1, (byte)5);








        }
    }
}
