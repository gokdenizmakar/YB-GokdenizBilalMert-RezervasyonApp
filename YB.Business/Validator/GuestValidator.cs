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
            RuleFor(g => g.FirstName).NotEmpty().WithMessage("Ad alanı boş geçilemez!")
                .MinimumLength(2).WithMessage("Ad alanı en az 2 karakter olmalıdır!")
                .MaximumLength(50).WithMessage("Ad alanı en fazla 50 karakter olabilir!")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen, ad alanına sadece harf girişi yapınız!");
            RuleFor(g => g.LastName).NotEmpty().WithMessage("Soyad alanı boş geçilemez!")
                .MinimumLength(2).WithMessage("Soyad alanı en az 2 karakter olmalıdır!")
                .MaximumLength(50).WithMessage("Soyad alanı en fazla 50 karakter olabilir!")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen, soyad alanına sadece harf girişi yapınız!");

            RuleFor(h => h.Address).NotEmpty().WithMessage("Adres alanı boş geçilemez!")
                .MaximumLength(255).WithMessage("Adres alanı en fazla 255 karakter olabilir!");

            RuleFor(h => h.Phone).NotEmpty().WithMessage("Telefon numarası alanı boş geçilemez!")
                .Length(11).WithMessage("Telefon numarası 11 karakter olmalıdır!");

            RuleFor(h => h.Email)
                 .NotEmpty().WithMessage("E-posta adresi boş olamaz!")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi!");

            RuleFor(x => x.TC).NotEmpty().WithMessage("TC alanı boş geçilemez!")
                .Length(11).WithMessage("TC alanı 11 karakter olmalı!");


        }
    }
}
