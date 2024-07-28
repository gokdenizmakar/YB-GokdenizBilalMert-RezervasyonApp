using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YB.Business.Abstractions;
using YB.Business.Validator;
using YB.DataAccess.Abstractions;
using YB.Entities.Models;

namespace YB.Business.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeDal roomTypeDal;

        public RoomTypeService(IRoomTypeDal _roomTypeDal)
        {
            roomTypeDal = _roomTypeDal;
        }
        public void Add(RoomType entity)
        {
            RoomTypeValidator rtVal = new RoomTypeValidator();
            ValidationResult result = rtVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }
            roomTypeDal.Add(entity);
        }

        public void Delete(Guid id)
        {
            if (roomTypeDal.IfEntityExists(x => x.ID == id))
            {
                throw new Exception("Silinecek oda tipi bulunamadı!");
            }
            roomTypeDal.Delete(id);
        }

        public IEnumerable<RoomType> GetAll()
        {
            return roomTypeDal.GetAll().Where(x => x.IsActive == true && x.IsDeleted == false);
        }


        public RoomType GetByID(Guid id)
        {
            if (id == default(Guid))
            {
                throw new Exception("Null ID değeri!");
            }
            return roomTypeDal.Get(x=>x.ID == id);
        }

        public bool IfEntityExists(Expression<Func<RoomType, bool>> filter)
        {
            if (filter == null)
            {
                throw new Exception("Oda tipi filtresi boş olamaz!(IfEntityExists)");
            }
            return roomTypeDal.IfEntityExists(filter);
        }

        public void Update(RoomType entity)
        {
            RoomTypeValidator rtVal = new RoomTypeValidator();
            ValidationResult result = rtVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors));
            }

            roomTypeDal.Update(entity);
        }

        //Değiştirilecek...
        public IEnumerable<Object> GetAllRoomTypeWithHotel(Guid hotelid)
        {
            return roomTypeDal.GetAllQueryable(x => x.ID != null).Include(x => x.Rooms).ThenInclude(x => x.Hotel).SelectMany(rt => rt.Rooms.Select(room => new
            {
                ID = rt.ID,
                Name = rt.Name,
                RoomID = room.ID,
                HotelID = room.Hotel.ID
            })).Where(x => x.HotelID == hotelid);
        }
    }
}
