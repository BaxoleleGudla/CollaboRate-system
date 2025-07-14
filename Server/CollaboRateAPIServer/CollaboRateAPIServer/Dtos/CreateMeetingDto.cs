namespace CollaboRateAPIServer.Dtos
{
    public class CreateMeetingDto
    {
        public int Group_ID { get; set; }
        public string Meeting_Title { get; set; }
        public string Meeting_Description { get; set; }
        public DateTime Meeting_Date { get; set; }
    }
}
