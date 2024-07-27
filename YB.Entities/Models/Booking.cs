using YB.Entities.Abstraction;

namespace YB.Entities.Models
{
    public class Booking : Base
    {
        public Room? Room { get; set; }
        public Guid RoomID { get; set; }
        public DateOnly CheckinDate { get; set; }
        public DateOnly CheckoutDate { get; set; }
        public double TotalPrice { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<Guest>? Guests { get; set; }
    }
}
