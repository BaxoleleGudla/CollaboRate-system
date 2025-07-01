namespace CollaboRateAPIServer.Dtos
{
    public class AcceptedGroupUsersDto
    {
        public int Group_ID { get; set; }
        public string Group_Name { get; set; }
        public string Group_Description { get; set; }
        public int Accepted_User_Count { get; set; }
        public List<GroupUserDto> Accepted_Users { get; set; }
    }

    public class GroupUserDto
    {
        public int User_ID { get; set; }
        public string Username { get; set; }
        public string User_Role { get; set; }
    }
}
