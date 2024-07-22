﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Models;

namespace YB.Business.Validator
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(p=>p.Amount).NotEmpty().WithMessage("Boş geçilemez")
                .InclusiveBetween((double)0, (double)99999999.99).WithMessage("Geçersiz ücret aralığı");

            RuleFor(p => p.PaymentMethod).MaximumLength(50).WithMessage("Ödeme yöntemi en fazla 50 karakter olmalıdır.");
            
        }
    }
}