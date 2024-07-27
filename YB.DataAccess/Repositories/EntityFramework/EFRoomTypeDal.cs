using YB.DataAccess.Abstractions;
using YB.DataAccess.Context;
using YB.Entities.Models;

namespace YB.DataAccess.Repositories.EntityFramework
{
    public class EFRoomTypeDal : EfGenericRepositoryDal<RoomType>, IRoomTypeDal
    {
        public EFRoomTypeDal(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}
