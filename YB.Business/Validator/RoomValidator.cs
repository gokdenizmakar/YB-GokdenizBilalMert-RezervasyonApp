using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Models;

namespace YB.Business.Validator
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(r => r.Status).MaximumLength(20).WithMessage("Oda durumu en fazla 20 karakter olabilir!");
        }
    }
}
