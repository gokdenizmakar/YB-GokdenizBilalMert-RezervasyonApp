using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YB.Entities.Abstraction
{
    public abstract class Base
    {
        protected Base()
        {
            CreatedDate = DateTime.Now;
            IsDeleted = false;
        }
        public int ID { get; }
        public DateTime CreatedDate { get; }
        public DateTime UpdatedDate { get; set; }
        public virtual bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
