using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Abstraction;

namespace YB.Entities.Models
{
    public class Booking:Base
    {
        public Room? Room { get; set; }
        public int RoomNumber { get; set; }
        public DateOnly CheckinDate { get; set; }
        public DateOnly CheckoutDate { get; set; }
        public double TotalPrice { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<Guest>? Guests { get; set; }
    }
}
