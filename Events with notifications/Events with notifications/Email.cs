using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_with_notifications
{
    public class Email
    {
        public User EmailOwner { get; private set; }
        public bool notificationsEnabled = false;
        public Email(User emailOwner)
        {
            EmailOwner = emailOwner;
        }
        public void OnSendNotifications(object obj, PostEventArgs e)
        {
            Console.WriteLine($"Notification was sent on {EmailOwner.Name}'s mail.");
        }
    }
}
