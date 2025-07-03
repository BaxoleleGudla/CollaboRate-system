namespace CollaboRateAPIServer.Dtos
{
    public class GroupWithRequestStatusDto
    {
        public int Group_ID { get; set; }
        public string Group_Name { get; set; }
        public bool HasPendingRequest { get; set; }
    }
}
