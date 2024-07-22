using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Entities.Abstraction;

namespace YB.Entities.Models
{
    public class RoomType :Base
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double PricePerNight { get; set; }
        public byte Capacity { get; set; }
    }
}
