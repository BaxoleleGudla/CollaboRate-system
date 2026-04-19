namespace CollaboRateAPIServer.Dtos
{
    public class RatedMemberDto
    {
        public int User_ID { get; set; } // Corresponds to Ratee_ID
        public string Username { get; set; }
        public byte? MyCurrentScore { get; set; }
        public double AverageScore { get; set; }
        public int ReceivedRatingsCount { get; set; } // To track number of ratings
        public int PotentialRatingsCount { get; set; }
        public string RatingStatus => $"{ReceivedRatingsCount} / {PotentialRatingsCount}";
    }
}
