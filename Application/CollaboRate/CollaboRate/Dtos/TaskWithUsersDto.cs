using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboRate.Dtos
{
    public class TaskWithUsersDto
    {
        public int Task_ID { get; set; }
        public string Task_Title { get; set; }
        public string Task_Description { get; set; } = null;
        public DateTime Deadline { get; set; }
        public List<string> AssignedUserNames { get; set; } = new List<string>();
        public string Status { get; set; }

        // New property for display in DataGridView
        public string AssignedUsersDisplay => string.Join(", ", AssignedUserNames);
    }
}
