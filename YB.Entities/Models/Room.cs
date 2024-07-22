using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Abstraction;

namespace YB.Entities.Models
{
    public class Room : Base
    {
        public Hotel? Hotel { get; set; }
        public int HotelID { get; set; }
        public RoomType? RoomType { get; set; }
        public int TypeID { get; set; }
        public string? Status { get; set; }
    }
}
