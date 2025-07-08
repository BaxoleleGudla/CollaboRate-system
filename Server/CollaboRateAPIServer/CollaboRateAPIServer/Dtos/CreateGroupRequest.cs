namespace CollaboRateAPIServer.Dtos
{
    public class CreateGroupRequest
    {
        public string Group_Name { get; set; }
        public string? Group_Description { get; set; }
        public int Creator { get; set; }
        public List<int> Member_User_IDs { get; set; } = new List<int>();
    }

    public class CreateGroupResponse
    {
        public int Group_ID { get; set; }
    }
}
