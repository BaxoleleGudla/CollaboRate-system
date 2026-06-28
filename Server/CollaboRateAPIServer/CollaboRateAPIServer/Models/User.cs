using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        // Optionally navigation back to assignments
        [JsonIgnore] // Make it nullable or ignore it during incoming requests
        [ValidateNever] // Tells ASP.NET Model State validator to skip it
        public ICollection<TaskAssignment> TaskAssignments { get; set; } = new List<TaskAssignment>();
    }
}
