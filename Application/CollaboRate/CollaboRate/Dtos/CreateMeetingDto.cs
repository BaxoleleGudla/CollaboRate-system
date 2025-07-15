using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboRate.Dtos
{
    public class CreateMeetingDto
    {
        public int Group_ID { get; set; }
        public string Meeting_Title { get; set; }
        public string Meeting_Description { get; set; }
        public DateTime Meeting_Date { get; set; }
    }
}
