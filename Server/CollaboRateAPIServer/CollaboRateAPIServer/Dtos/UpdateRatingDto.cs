namespace CollaboRateAPIServer.Dtos
{
    public class UpdateRatingDto
    {
        public int Group_ID { get; set; }
        public int Rater_ID { get; set ; }
        public int Ratee_ID { get; set ; }
        public byte Score {  get; set ; }
    }
}
