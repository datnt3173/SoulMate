namespace BusinessLogicLayer.Viewmodels.User
{
    public class UserDataVM
    {
        public string ID { get; set; } = null!;
        public string ImageLink { get; set; } = null!;
        public string FirstAndLastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? ModifieDate { get; set; }
        public string? ModifieBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string? DeleteBy { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public int Status { get; set; } = 1;
    }
}
