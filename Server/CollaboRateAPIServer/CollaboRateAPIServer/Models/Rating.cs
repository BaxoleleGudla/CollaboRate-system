using System.ComponentModel.DataAnnotations;

namespace CollaboRateAPIServer.Models
{
    public class Rating
    {
        [Key]
        public int Rating_ID { get; set; }
        public int Group_ID { get; set; }
        public int Rater_ID { get; set; }
        public int Ratee_ID { get; set; }
        public int Score {  get; set; }
        public DateTime Rated_At { get; set; }
    }
}
