using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CollaboRateAPIServer.Data;
using System.Runtime.Versioning;
using CollaboRateAPIServer.Dtos;

namespace CollaboRateAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/groups/user
        // Gets all groups (Group ID and Name) that the user with the specified User_ID is in
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroupsForUser(int userId)
        {
            var groups = await _context.tblGroupMember
                .Where(gm => gm.User_ID == userId && gm.Join_Status == "Accepted")
                .Include(gm => gm.Group)
                .Select(gm => new GroupDto
                {
                    Group_ID = gm.Group.Group_ID,
                    Group_Name = gm.Group.Group_Name
                })
                .ToListAsync();

            if (groups == null || groups.Count == 0)
            {
                return NotFound("No groups found for user with ID " + userId);
            }

            return Ok(groups);
        }

        // GET: api/groups/{groupId}/details-with-accepted-users
        [HttpGet("{groupId}/details-with-accepted-users")]
        public async Task<ActionResult<AcceptedGroupUsersDto>> GetGroupsWithAcceptedUsers(int groupId)
        {
            var groupData = await _context.tblGroup
                .Where(g => g.Group_ID == groupId)
                .Select(g => new AcceptedGroupUsersDto
                {
                    Group_ID = g.Group_ID,
                    Group_Name = g.Group_Name,
                    Group_Description = g.Group_Description,
                    Accepted_Users = g.GroupMembers
                        .Where(gm => gm.Join_Status == "Accepted")
                        .Select(gm => new GroupUserDto
                        {
                            User_ID = gm.User.User_ID,
                            Username = gm.User.Username,
                            User_Role = gm.User_Role
                        })
                        .ToList(),
                    Accepted_User_Count = g.GroupMembers.Count(gm => gm.Join_Status == "Accepted")
                })
                .FirstOrDefaultAsync();

            if (groupData == null)
            {
                return NotFound("Group with ID " + groupId + " not found.");
            }

            return Ok(groupData);
        }
    }

    // DTO to return minimal group info
    public class GroupDto
    {
        public int Group_ID { get; set; }
        public string Group_Name { get; set; }
    }
}
