using System.ComponentModel.DataAnnotations;

namespace CollaboRateAPIServer.Models
{
    public class TaskAssignment
    {
        [Key]
        public int Task_Assignment_ID { get; set; }

        public int Task_ID { get; set; }
        // Navigation properties
        public Task? Task { get; set; }

        public int User_ID { get; set; }
        // Add this navigation property to enable access to User
        public User? User { get; set; }

        public bool Is_Completed { get; set; }
        public DateTime? Completed_At { get; set; }
        public string? Note { get; set; }
    }
}
