using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboRate.Dtos
{
    public class UserWithTaskAssignmentDto
    {
        public int User_ID { get; set; }
        public string Username { get; set; } = null;
        public bool IsInTask { get; set; }
    }
}
