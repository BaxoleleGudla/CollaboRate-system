namespace CollaboRateAPIServer.Dtos
{
    public class UserRegisterResponseDto
    {
        public int User_ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Created_At { get; set; }
    }
}
