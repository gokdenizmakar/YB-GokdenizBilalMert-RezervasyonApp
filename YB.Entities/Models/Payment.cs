using YB.Entities.Abstraction;

namespace YB.Entities.Models
{
    public class Payment : Base
    {
        public Booking? Booking { get; set; }
        public Guid BookingID { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }

    }
}
