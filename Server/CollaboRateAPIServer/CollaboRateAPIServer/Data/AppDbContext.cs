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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure TaskAssignment entity
            modelBuilder.Entity<TaskAssignment>(entity =>
            {
                // Primary key
                entity.HasKey(e => e.Task_Assignment_ID);

                // Relationship: TaskAssignment -> Task (many-to-one)
                entity.HasOne(e => e.Task)
                    .WithMany(t => t.TaskAssignments)    
                    .HasForeignKey(e => e.Task_ID)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relationship: TaskAssignment -> User (many-to-one)
                entity.HasOne(e => e.User)
                    .WithMany(u => u.TaskAssignments)    
                    .HasForeignKey(e => e.User_ID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
