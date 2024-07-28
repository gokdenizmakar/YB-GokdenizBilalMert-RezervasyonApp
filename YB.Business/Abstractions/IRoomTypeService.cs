using YB.Entities.Models;

namespace YB.Business.Abstractions
{
    public interface IRoomTypeService : IGenericService<RoomType>
    {
        public IEnumerable<Object> GetAllRoomTypeWithHotel(Guid hotelid);
    }
}
