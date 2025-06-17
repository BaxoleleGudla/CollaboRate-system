using System.ComponentModel.DataAnnotations;

namespace CollaboRateAPIServer.Models
{
    public class GroupNotification
    {
        [Key]
        public int Group_Notification_ID { get; set; }
        public int Group_ID { get; set; }
        public string Notification_Type { get; set; }
        public string Notification_Message { get; set; }
        public DateTime Created_At { get; set; }
    }
}
