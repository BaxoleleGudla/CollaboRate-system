using System.ComponentModel.DataAnnotations;

namespace CollaboRateAPIServer.Models
{
    public class Meeting
    {
        [Key]
        public int Meeting_ID { get; set; }
        public int Group_ID { get; set; }
        public string Meeting_Title { get; set; }
        public string Meeting_Description { get; set; }
        public DateTime Meeting_Date { get; set; }
        public DateTime Created_At { get; set; }
    }
}
