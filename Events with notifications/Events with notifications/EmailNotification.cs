using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_with_notifications
{
    public class EmailNotification
    {
        public void OnSendNotifications(object obj, PostEventArgs e)
        {
            Console.WriteLine($"Sent message on mail of {e.Post.UserAccount}");
        }
    }
}
