using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboRate.Dtos
{
    public class UpdateUserDto
    {
        public int User_ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
