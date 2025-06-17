using System.ComponentModel.DataAnnotations;

namespace CollaboRateAPIServer.Models
{
    public class TaskAssignment
    {
        [Key]
        public int Task_Assignment_ID { get; set; }
        public int Task_ID { get; set; }
        public int User_ID { get; set; }
        public bool Is_Completed { get; set; }
        public DateTime Created_At { get; set; }
        public string Note { get; set; }
    }
}
