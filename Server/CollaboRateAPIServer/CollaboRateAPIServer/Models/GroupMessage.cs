using System.ComponentModel.DataAnnotations;

namespace CollaboRateAPIServer.Models
{
    public class GroupMessage
    {
        [Key]
        public int Message_ID { get; set; }
        public int Sender_ID { get; set; }
        public int Group_ID { get; set; }
        public string Message_Text { get; set; }
        public DateTime Created_At { get; set; }
    }
}
