namespace CollaboRateAPIServer.Dtos
{
    public class AddUsersToGroupRequest
    {
        public int Group_ID { get; set; }
        public List<int> User_IDs { get; set; } = new List<int>();
    }
}
