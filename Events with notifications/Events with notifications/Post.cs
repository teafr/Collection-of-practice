using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_with_notifications
{
    public class Post
    {
        public User UserAccount { get; }
        public string Description { get; private set; }
        public DateTime WhenWasPublished { get; }
        public Post(User user, string description)
        {
            WhenWasPublished = DateTime.Now;
            UserAccount = user;
            Description = description;
        }
        public void ChangeDescription(User userWhoMakesChanges, string description)
        {
            if (UserAccount.Id == userWhoMakesChanges.Id)
            {
                Description = description;
                Console.WriteLine("Description was successfully changed");
            }
            else
                Console.WriteLine("User can't change someone's post");
        }
    }
}
