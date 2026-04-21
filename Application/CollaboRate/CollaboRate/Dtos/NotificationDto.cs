using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboRate.Dtos
{
    public class NotificationDto
    {
        public int RecipientID { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public DateTime Created_At { get; set; }
        public bool IsRead { get; set; }
    }
}
