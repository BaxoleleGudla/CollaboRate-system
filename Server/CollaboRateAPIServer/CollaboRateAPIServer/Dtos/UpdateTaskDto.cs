namespace CollaboRateAPIServer.Dtos
{
    public class UpdateTaskDto
    {
        public int Task_ID { get; set; }
        public string Task_Title { get; set; }
        public string? Task_Description { get; set; }
        public DateTime Deadline { get; set; }
        public List<int>? AssignedUserIds { get; set; }
        public bool Is_Completed { get; set; } // Shared completion
    }
}
