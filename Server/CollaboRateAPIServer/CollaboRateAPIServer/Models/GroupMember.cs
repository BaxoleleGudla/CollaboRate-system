using System.ComponentModel.DataAnnotations;

namespace CollaboRateAPIServer.Models
{
    public class GroupMember
    {
        [Key]
        public int Group_Member_ID { get; set; }
        public int Group_ID { get; set; }
        public int User_ID { get; set; }
        public string User_Role { get; set; }
        public string Join_Status { get; set; }
        public DateTime Joined_At { get; set; }
    }
}
