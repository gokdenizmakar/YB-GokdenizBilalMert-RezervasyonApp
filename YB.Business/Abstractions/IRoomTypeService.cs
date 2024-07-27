using YB.Entities.Models;

namespace YB.Business.Abstractions
{
    public interface IRoomTypeService : IGenericService<RoomType>
    {
        public IQueryable<Object> GetAllRoomTypeWithHotel(Guid hotelid);
    }
}
