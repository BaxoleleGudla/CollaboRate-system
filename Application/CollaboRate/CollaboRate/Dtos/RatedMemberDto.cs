using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboRate.Dtos
{
    public class RatedMemberDto
    {
        public int User_ID { get; set; }
        public string Username { get; set; }
        public byte? MyCurrentScore { get; set; }
        public double AverageScore { get; set; }
        public int ReceivedRatingsCount { get; set; }
        public int PotentialRatingsCount { get; set; }
        public string RatingStatus => $"{ReceivedRatingsCount} / {PotentialRatingsCount}";
    }
}
