namespace CollaboRateAPIServer.Dtos
{
    public class UserWithTaskAssignmentDto
    {
        public int User_ID { get; set; }
        public string Username { get; set; } = null;
        public bool IsInTask { get; set; }
    }
}
