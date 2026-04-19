using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboRate.Dtos
{
    public class RatingUpdateDto
    {
        public int Group_ID { get; set; }
        public int Rater_ID { get; set; }
        public int Ratee_ID { get; set; }
        public byte Score { get; set; }
    }
}
