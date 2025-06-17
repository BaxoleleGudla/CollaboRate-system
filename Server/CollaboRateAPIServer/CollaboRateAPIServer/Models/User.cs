using System.ComponentModel.DataAnnotations;

namespace CollaboRateAPIServer.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime Created_At { get; set; }
    }
}
