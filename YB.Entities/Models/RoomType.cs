using YB.Entities.Abstraction;

namespace YB.Entities.Models
{
    public class RoomType : Base
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public byte Capacity { get; set; }
        public ICollection<Room>? Rooms { get; set; }
    }
}
