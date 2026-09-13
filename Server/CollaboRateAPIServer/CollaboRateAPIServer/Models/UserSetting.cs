using System.ComponentModel.DataAnnotations;

namespace CollaboRateAPIServer.Models
{
    public class UserSetting
    {
        [Key]
        public int User_ID { get; set; }
        public bool Enable_Push_Notifications { get; set; }
        public bool Enable_Email_Notifications { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
