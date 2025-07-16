using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboRate.Dtos
{
    public class UpdateMeetingDto
    {
        public string Meeting_Title { get; set; }
        public string Meeting_Description { get; set; }
        public DateTime Meeting_Date { get; set; }
    }
}
