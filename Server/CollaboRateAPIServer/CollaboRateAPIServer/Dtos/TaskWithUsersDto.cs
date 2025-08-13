namespace CollaboRateAPIServer.Dtos
{
    public class TaskWithUsersDto
    {
        public int Task_ID { get; set; }
        public string Task_Title { get; set; }
        public string? Task_Description { get; set; }
        public DateTime Deadline { get; set; }
        public List<string> AssignedUserNames { get; set; } = new List<string>();
        public string Status { get; set; }

        // New property for display in DataGridView
        public string AssignedUsersDisplay => string.Join(", ", AssignedUserNames);
    }
}
