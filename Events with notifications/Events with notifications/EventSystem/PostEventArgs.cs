using Events_with_notifications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_with_notifications.EventSystem
{
    public class PostEventArgs : EventArgs
    {
        public Post Post { get; }
        public PostEventArgs(Post post)
        {
            Post = post;
        }
    }
}
