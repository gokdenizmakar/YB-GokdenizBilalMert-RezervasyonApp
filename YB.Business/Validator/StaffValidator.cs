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
            RuleFor(g => g.FirstName).NotEmpty().WithMessage("Ad  boş geçilemez.")
                .MinimumLength(5).WithMessage("Ad  5 minimum karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Ad maximum 50 karakter olabilir.")
            .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen sadece harf girişi yapınız.");

            RuleFor(g => g.LastName).NotEmpty().WithMessage("Soyad boş geçilemez.")
               .MinimumLength(5).WithMessage("Soyad  5 minimum karakter olmalıdır.")
               .MaximumLength(50).WithMessage("Soyad maximum 50 karakter olabilir.")
               .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen sadece harf girişi yapınız.");

            RuleFor(s => s.Position)
                .MaximumLength(50).WithMessage("Pozisyon adı maximum 50 karakter olabilir.")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen sadece harf girişi yapınız.");

            RuleFor(s => s.Salary).InclusiveBetween((double)0, (double)99999999.99).WithMessage("Geçersiz ücret aralığı");

            RuleFor(x => new { x.DateOfBirth, x.HireDate })
            .Must(dates => dates.DateOfBirth < dates.HireDate)
            .WithMessage("Lütfen işe başlamadan önce doğunuz.");

            RuleFor(s => s.Phone).NotEmpty().WithMessage("Telefon numarası alanı boş geçilemez.")
                 .Length(11).WithMessage("Otel adı maximum 50 karakter olabilir.");

            RuleFor(s => s.Email)
                 .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi formatı.");

        }

    }
}
