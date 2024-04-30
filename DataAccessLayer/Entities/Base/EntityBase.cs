namespace DataAccessLayer.Entities.Base
{
    public class EntityBase
    {
        public Guid ID { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string? DeleteBy { get; set; }
        //public bool IsActive { get; set; }
        public int Status { get; set; }
    }
}