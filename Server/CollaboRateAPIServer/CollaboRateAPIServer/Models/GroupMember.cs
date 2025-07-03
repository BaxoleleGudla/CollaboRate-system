using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollaboRateAPIServer.Models
{
    public class GroupMember
    {
        [Key]
        public int Group_Member_ID { get; set; }
        public int Group_ID { get; set; }
        public int User_ID { get; set; }

        // Navigation properties 
        [ForeignKey("Group_ID")]
        public Group Group { get; set; }

        [ForeignKey("User_ID")]
        public User User { get; set; }

        public string User_Role { get; set; }
        public string Join_Status { get; set; }
        public DateTime? Joined_At { get; set; }
    }
}
