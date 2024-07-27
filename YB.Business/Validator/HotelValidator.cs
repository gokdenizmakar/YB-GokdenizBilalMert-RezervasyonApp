using FluentValidation;
using YB.Entities.Models;

namespace YB.Business.Validator
{
    public class HotelValidator : AbstractValidator<Hotel>
    {
        public HotelValidator()
        {
            RuleFor(h => h.Name).NotEmpty().WithMessage("Hotel ad alanı boş geçilemez!")
                .MinimumLength(2).WithMessage("Hotel adı alanı en az 2 karakter olmalıdır!")
                .MaximumLength(50).WithMessage("Hotel adı alanı en fazla 50 karakter olabilir!")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen, hotel adı alanına sadece harf girişi yapınız!");

            RuleFor(h => h.Address).NotEmpty().WithMessage("Adres alanı boş geçilemez!")
                .MaximumLength(255).WithMessage("Adres alanı en fazla 255 karakter olabilir!");

            RuleFor(h => h.Phone).NotEmpty().WithMessage("Telefon numarası alanı boş geçilemez!")
                .Length(11).WithMessage("Telefon numarası 11 karakter olmalıdır!");

            RuleFor(h => h.Email)
                 .NotEmpty().WithMessage("E-posta adresi boş olamaz!")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi!");

            RuleFor(h => h.Stars).InclusiveBetween((byte)1, (byte)5).WithMessage("Hotel yıldızıen az 1, en fazla 5 olabilir!");








        }
    }
}
