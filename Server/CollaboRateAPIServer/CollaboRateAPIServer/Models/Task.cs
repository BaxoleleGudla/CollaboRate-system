using System.ComponentModel.DataAnnotations;

namespace CollaboRateAPIServer.Models
{
    public class Task
    {
        [Key]
        public int Task_ID { get; set; }
        public int Group_ID { get; set; }
        public string Task_Title { get; set; }
        public string Task_Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime Created_At { get; set; }
    }
}
