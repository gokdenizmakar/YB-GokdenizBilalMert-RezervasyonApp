using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Models;

namespace YB.Business.Abstractions
{
    public interface IRoomTypeService : IGenericService<RoomType>
    {
        public IQueryable<Object> GetAllRoomTypeWithHotel(Guid hotelid);
    }
}
