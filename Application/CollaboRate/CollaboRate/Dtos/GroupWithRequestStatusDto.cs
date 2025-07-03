using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboRate.Dtos
{
    public class GroupWithRequestStatusDto
    {
        public int Group_ID { get; set; }
        public string Group_Name { get; set; }
        public bool HasPendingRequest { get; set; }
    }
}
