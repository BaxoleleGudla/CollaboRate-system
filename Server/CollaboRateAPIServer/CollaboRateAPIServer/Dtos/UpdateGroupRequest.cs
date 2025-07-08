namespace CollaboRateAPIServer.Dtos
{
    public class UpdateGroupRequest
    {
        public int Group_ID { get; set; }
        public string Group_Name { get; set; }
        public string Group_Description { get; set; }
        public List<UpdateGroupMemberRoleDto> Members { get; set; } = new List<UpdateGroupMemberRoleDto>();
    }

    public class UpdateGroupMemberRoleDto
    {
        public int User_ID { get; set; }
        public string User_Role { get; set; }
    }
}
