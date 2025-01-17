﻿using YB.Entities.Abstraction;

namespace YB.Entities.Models
{
    public class Staff : Base
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public double Salary { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateOnly HireDate { get; set; }
        public Hotel? Hotel { get; set; }
        public Guid HotelID { get; set; }
    }
}
