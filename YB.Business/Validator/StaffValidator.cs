using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Models;

namespace YB.Business.Validator
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(g => g.FirstName).NotEmpty().WithMessage("Ad alanı boş geçilemez!")
                .MinimumLength(2).WithMessage("Ad alanı en az 2 karakter olmalıdır!")
                .MaximumLength(50).WithMessage("Ad alanı en fazla 50 karakter olabilir!")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen, ad alanına sadece harf girişi yapınız!");

            RuleFor(g => g.LastName).NotEmpty().WithMessage("Soyad alanı boş geçilemez!")
                .MinimumLength(2).WithMessage("Soyad alanı en az 2 karakter olmalıdır!")
                .MaximumLength(50).WithMessage("Soyad alanı en fazla 50 karakter olabilir!")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen, soyad alanına sadece harf girişi yapınız!");

            RuleFor(s => s.Position)
                .MaximumLength(50).WithMessage("Pozisyon adı en fazla 50 karakter olabilir!")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen sadece harf girişi yapınız!");

            RuleFor(s => s.Salary).InclusiveBetween((double)0, (double)99999999.99).WithMessage("Geçersiz ücret aralığı!");

            RuleFor(x => new { x.DateOfBirth, x.HireDate })
            .Must(dates => dates.DateOfBirth < dates.HireDate)
            .WithMessage("Lütfen işe başlamadan önce doğunuz!!!");

            RuleFor(s => s.Phone).NotEmpty().WithMessage("Telefon numarası alanı boş geçilemez!")
                 .Length(11).WithMessage("Telefon numarası 11 karakter olmalıdır!");

            RuleFor(s => s.Email)
                 .NotEmpty().WithMessage("E-posta adresi boş olamaz!")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi!");

        }

    }
}
