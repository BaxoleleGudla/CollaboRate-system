using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboRate.Dtos
{
    public class UpdateTaskDto
    {
        public int Task_ID { get; set; }
        public string Task_Title { get; set; }
        public string Task_Description { get; set; } = null;
        public DateTime Deadline { get; set; }
        public List<int> AssignedUserIds { get; set; } = null;
        public bool Is_Completed { get; set; } // Shared completion
    }
}
