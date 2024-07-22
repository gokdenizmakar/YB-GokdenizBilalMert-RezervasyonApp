﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Models;

namespace YB.Business.Validator
{
    public class BookingValidator:AbstractValidator<Booking>
    {
        public BookingValidator()
        {

            RuleFor(b => b.TotalPrice).InclusiveBetween((double)0, (double)99999999.99).WithMessage("Geçersiz ücret aralığı");
    
            RuleFor(x => new { x.CheckinDate, x.CheckoutDate })
            .Must(dates => dates.CheckinDate < dates.CheckoutDate)
            .WithMessage("Başlangıç tarihi bitiş tarihinden önce olmalıdır.");
        }
    }
}