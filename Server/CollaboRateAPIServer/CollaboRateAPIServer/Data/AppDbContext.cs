using Microsoft.EntityFrameworkCore;
using CollaboRateAPIServer.Models;

namespace CollaboRateAPIServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> tblUser { get; set; }
        public DbSet<Group> tblGroup { get; set; }
        public DbSet<GroupMember> tblGroupMember { get; set; }
        public DbSet<GroupMessage> tblGroupMessage { get; set; }
        public DbSet<GroupNotification> tblGroupNotification { get; set; }
        public DbSet<Meeting> tblMeeting { get; set; }
        public DbSet<NotificationRecipient> tblNotificationRecipient { get; set; }
        public DbSet<Rating> tblRating { get; set; }
        public DbSet<Models.Task> tblTask { get; set; }
        public DbSet<TaskAssignment> tblTaskAssignment { get; set; }
    }
}
