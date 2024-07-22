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
            ID= Guid.NewGuid();
            CreatedDate = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
        }
        public Guid ID { get; }
        public DateTime CreatedDate { get; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
