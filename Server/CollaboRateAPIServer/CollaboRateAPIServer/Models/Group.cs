using System.ComponentModel.DataAnnotations;

namespace CollaboRateAPIServer.Models
{
    public class Group
    {
        [Key]
        public int Group_ID { get; set; }
        public string Group_Name { get; set; }
        public string Group_Description { get; set; }
        public int Creator {  get; set; }
        public DateTime Created_At { get; set; }
    }
}
