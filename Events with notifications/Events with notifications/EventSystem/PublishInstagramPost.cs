using Events_with_notifications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_with_notifications.EventSystem
{
    public class PublishInstagramPost
    {
        public event EventHandler<PostEventArgs>? SendMessages;

        public void Publish(Post post)
        {
            Console.WriteLine($"Publish {post.UserAccount.Name}'s post with \"{post.Description}\" description...");
            Thread.Sleep(3000);
            OnSendNotifications(post);
            Console.WriteLine("All messages were sent.");
        }
        protected virtual void OnSendNotifications(Post post)
        {
            if (SendMessages != null)
                this?.SendMessages(this, new PostEventArgs(post));
        }
    }
}
