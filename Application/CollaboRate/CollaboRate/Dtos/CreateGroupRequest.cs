using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboRate.Dtos
{
    public class CreateGroupRequest
    {
        public string Group_Name { get; set; }
        public string Group_Description { get; set; }
        public int Creator { get; set; }
        public List<int> Member_User_IDs { get; set; } = new List<int>();
    }
}
