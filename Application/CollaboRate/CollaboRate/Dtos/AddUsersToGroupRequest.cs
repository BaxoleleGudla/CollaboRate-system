using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboRate.Dtos
{
    public class AddUsersToGroupRequest
    {
        public int Group_ID { get; set; }
        public List<int> User_IDs { get; set; } = new List<int>();
    }
}
