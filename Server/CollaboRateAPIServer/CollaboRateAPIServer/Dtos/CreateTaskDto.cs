namespace CollaboRateAPIServer.Dtos
{
    public class CreateTaskDto
    {
        public int Group_ID { get; set; }
        public string Task_Title { get; set; }
        public string? Task_Description { get; set; }
        public DateTime Deadline { get; set; }
        public List<int> AssignedUserIds { get; set; }
    }
}
