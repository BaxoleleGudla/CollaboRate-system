using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboRate.Dtos
{
    public class MessageDto
    {
        public int Message_ID { get; set; }
        public int Group_ID { get; set; }
        public string Message_Text { get; set; }
        public DateTime Created_At { get; set; }
        public string SenderUsername { get; set; }
    }
}
