using System.ComponentModel.DataAnnotations;

namespace CollaboRateAPIServer.Models
{
    public class NotificationRecipient
    {
        [Key]
        public int Notification_Recipient_ID { get; set; }
        public int Group_Notification_ID { get; set; }
        public int User_ID { get; set; }
        public bool Is_Read { get; set; }
    }
}
