﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Abstraction;

namespace YB.Entities.Models
{
    public class Guest:Base
    {
        public string? FirstName  { get; set; }
        public string? LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

    }
}