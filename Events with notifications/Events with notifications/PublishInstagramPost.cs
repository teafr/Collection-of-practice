﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_with_notifications
{
    public class PublishInstagramPost
    {
        public event EventHandler<PostEventArgs> SendMessages;

        public void Publish(Post post)
        {
            Console.WriteLine($"Publish {post.UserAccount} post with \"{post.Description}\" description...");
            Thread.Sleep(3000);
            OnSendNotifications(post);
            Console.WriteLine("All messages were sent.");
        }
        protected virtual void OnSendNotifications(Post post)
        {
            this?.SendMessages(this, new PostEventArgs(post));
        }
    }
}
