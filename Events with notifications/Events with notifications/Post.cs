using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Events_with_notifications.Instagram;

namespace Events_with_notifications
{
    public class Post
    {
        public int Id { get; set; }
        public User UserAccount { get; }
        public string Description { get; private set; }
        public DateTime WhenWasPublished { get; }
        public Post(User user, string description)
        {
            WhenWasPublished = DateTime.Now;
            Id = postId++;
            UserAccount = user;
            Description = description;
        }
        public void ChangeDescription(string description)
        {
            Description = description;
        }
    }
}
