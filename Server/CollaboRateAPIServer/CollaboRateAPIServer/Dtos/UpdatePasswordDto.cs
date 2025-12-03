namespace CollaboRateAPIServer.Dtos
{
    public class UpdatePasswordDto
    {
        public int User_ID { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
