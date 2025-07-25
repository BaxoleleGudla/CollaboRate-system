namespace CollaboRateAPIServer.Dtos
{
    public class RatedMemberDto
    {
        public int User_ID { get; set; } // Corresponds to Ratee_ID
        public string Username { get; set; }
        public byte Score { get; set; }
        public double Average_Score { get; set; }
    }
}
