namespace BusinessLogicLayer.Viewmodels.UserChatRooms
{
    public class UserChatRoomsUpdateVM
    {
        public string ModifiedBy { get; set; }
        public string CreateBy { get; set; }
        public string IDUser { get; set; } = null!;
        public Guid IDChatRoom { get; set; }
        public int Status { get; set; }
    }
}
