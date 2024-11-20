using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_with_notifications
{
    public class Post
    {
        public int Id { get; set; }
        public User UserAccount { get; }
        public string Description { get; private set; }
        public DateTime WhenWasPublished { get; }
        public Post(User user, string description, int id)
        {
            WhenWasPublished = DateTime.Now;
            Id = id;
            UserAccount = user;
            Description = description;
        }
        public void ChangeDescription(User whoMakesChanges, string description)
        {
            if (UserAccount.Id == whoMakesChanges.Id)
            {
                Description = description;
                Console.WriteLine("Description was successfully changed");
            }
            else
                Console.WriteLine("User can't change someone's post");
        }
    }
}
