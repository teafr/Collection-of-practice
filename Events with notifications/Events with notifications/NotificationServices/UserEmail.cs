using Events_with_notifications.EventSystem;
using Events_with_notifications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_with_notifications.NotificationServices
{
    public class UserEmail
    {
        public User EmailOwner { get; private set; }

        //public bool NotificationsEnabled { get; set; }

        public UserEmail(User emailOwner)
        {
            EmailOwner = emailOwner;
        }
        public void OnSendNotifications(object obj, PostEventArgs e)
        {
            Console.WriteLine($"Notification was sent on {EmailOwner.Name}'s mail.");
        }
    }
}
