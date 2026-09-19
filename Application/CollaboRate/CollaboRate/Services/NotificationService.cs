using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;

namespace CollaboRate.Services
{
    public class NotificationService
    {
        public static void ShowNewMeetingNotification(string meetingTitle, string scheduledTime)
        {
            new ToastContentBuilder()
                .AddText("📅 New Meeting Scheduled")
                .AddText(scheduledTime)
                .Show();
        }

        public static void ShowMeetingUpdatedNotification(string meetingTitle, string updateDetails)
        {
            new ToastContentBuilder()
                .AddText("✏️ Meeting Updated")
                .AddText(updateDetails)
                .Show();
        }

        public static void ShowMeetingCancelledNotification(string meetingTitle)
        {
            new ToastContentBuilder()
                .AddText("❌ Meeting Cancelled")
                .AddText(meetingTitle)
                .Show();
        }

        public static void ShowJoinRequestNotification(string message)
        {
            new ToastContentBuilder()
                .AddText("👤 Join Request")
                .AddText(message)
                .Show();
        }

        public static void ShowTaskDeletedNotification(string taskTitle)
        {
            new ToastContentBuilder()
                .AddText("❌ Task Deleted")
                .AddText(taskTitle)
                .Show();
        }
    }
}
