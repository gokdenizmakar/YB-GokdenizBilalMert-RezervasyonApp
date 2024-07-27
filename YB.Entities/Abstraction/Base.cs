namespace YB.Entities.Abstraction
{
    public abstract class Base : IEntity
    {
        protected Base()
        {
            ID = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
        }
        public Guid ID { get; set; }
        public DateTime CreatedDate { get; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
