using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Models;

namespace YB.Business.Validator
{
    public class RoomTypeValidator : AbstractValidator<RoomType>
    {
        public RoomTypeValidator()
        {
            RuleFor(rt => rt.Name).NotEmpty().WithMessage("Oda tipi alanı boş geçilemez!")
              .MinimumLength(3).WithMessage("Oda tipi en az 3 karakter olabilir!")
              .MaximumLength(50).WithMessage("Oda tipi en fazla 50 karakter olabilir!")
              .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage("Lütfen sadece harf girişi yapınız!");
            RuleFor(rt => rt.Description)
               .MaximumLength(255).WithMessage("Açıklama en fazla 255 karakter olabilir!");

            RuleFor(rt => rt.Capacity).InclusiveBetween((byte)1, (byte)4).WithMessage("Oda kapasitesi en fazla 4 kişi olabilir!");


        }
    }
}
