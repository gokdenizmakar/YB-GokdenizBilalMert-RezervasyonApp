using FluentValidation.Results;
using System.Linq.Expressions;
using YB.Business.Abstractions;
using YB.Business.Validator;
using YB.DataAccess.Abstractions;
using YB.Entities.Models;

namespace YB.Business.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomDal roomDal;

        public RoomService(IRoomDal _roomDal)
        {
            roomDal = _roomDal;
        }
        public void Add(Room entity)
        {
            RoomValidator rVal = new RoomValidator();
            ValidationResult result = rVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }
            roomDal.Add(entity);
        }

        public void Delete(Guid id)
        {
            if (roomDal.IfEntityExists(x => x.ID == id))
            {
                throw new Exception("Silinecek oda bulunamadı!");
            }
            roomDal.Delete(id);
        }

        public Room Get(Expression<Func<Room, bool>> filter)
        {
            if (filter == null)
            {
                throw new Exception("Oda filtresi boş olamaz!(Get)");
            }
            return roomDal.Get(filter);
        }

        public IEnumerable<Room> GetAll()
        {
            return roomDal.GetAll().Where(x => x.IsActive == true && x.IsDeleted == false);
        }

        public IQueryable<Room> GetAllQueryable(Expression<Func<Room, bool>> filter)
        {
            if (filter == null)
            {
                throw new Exception("Oda filtresi boş olamaz!(GetAllQueryable)");
            }
            return roomDal.GetAllQueryable(filter);
        }

        public Room GetByID(Guid id)
        {
            if (id == default(Guid))
            {
                throw new Exception("Null ID değeri!");
            }
            return roomDal.GetByID(id);
        }

        public bool IfEntityExists(Expression<Func<Room, bool>> filter)
        {
            if (filter == null)
            {
                throw new Exception("Oda filtresi boş olamaz!(IfEntityExists)");
            }
            return roomDal.IfEntityExists(filter);
        }

        public void Update(Room entity)
        {
            RoomValidator rVal = new RoomValidator();
            ValidationResult result = rVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }
            roomDal.Update(entity);
        }
    }
}
