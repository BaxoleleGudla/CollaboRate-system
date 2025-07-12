namespace CollaboRateAPIServer.Dtos
{
    public class TaskDto
    {
        public int Task_ID { get; set; }
        public string Task_Title { get; set; }
        public string Task_Description { get; set; }
        public DateTime Deadline { get; set; }
        public List<string> AssignedUsers { get; set; }
        public string Status { get; set; }
        public bool IsCompleted { get; set; }
    }
}
