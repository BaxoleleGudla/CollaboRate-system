namespace CollaboRateAPIServer.Dtos
{
    public class NotificationDto
    {
        public int RecipientID { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
    }
}
