namespace BusinessLogicLayer.Viewmodels.UserChatRooms
{
    public class UserChatRoomsVM
    {
        public Guid ID { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string IDUser { get; set; } = null!;
        public Guid IDChatRoom { get; set; }
        public int Status { get; set; }
    }
}
