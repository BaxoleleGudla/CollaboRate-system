using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollaboRateAPIServer.Models
{
    public class Group
    {
        [Key]
        public int Group_ID { get; set; }
        public string Group_Name { get; set; }
        public string Group_Description { get; set; }
        public int Creator {  get; set; }
		
		[ForeignKey("Creator")]
		public User CreatorUser { get; set; }
		
        public DateTime Created_At { get; set; }

        // Add this navigation property to represent related GroupMembers
        public ICollection<GroupMember> GroupMembers { get; set; }
    }
}
