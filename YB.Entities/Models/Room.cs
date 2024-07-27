using YB.Entities.Abstraction;

namespace YB.Entities.Models
{
    public class Room : Base
    {
        public Hotel? Hotel { get; set; }
        public Guid HotelID { get; set; }
        public RoomType? RoomType { get; set; }
        public Guid RoomTypeID { get; set; }
        public string? RoomNumber { get; set; }
        public string? Status { get; set; }
        public double PricePerNight { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
