using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_with_notifications
{
    public class AppNotification
    {
        public void OnSendNotifications(object obj, PostEventArgs e)
        {
            Console.WriteLine($"Sent message in app on account {e.Post.UserAccount}");
        }
    }
}
