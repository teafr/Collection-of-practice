using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Events_with_notifications.Instagram;

namespace Events_with_notifications
{
    public class User
    {
        public int Id { get; }
        public string Name { get; private set; }
        public Email EmailOfUser { get; private set; }
        public AppNotification AppNotification { get; private set; }
        public List<Post> Posts { get; } = new List<Post>();
        public List<User> Subscribers { get; private set; } = new List<User>();
        public List<User> Subscriptions { get; private set; } = new List<User>();
        public PublishInstagramPost PublishInstagramPost { get; } = new PublishInstagramPost();
        
        public User(string name)
        {
            Id = userId++;
            Name = name;
            EmailOfUser = new Email(this);
            AppNotification = new AppNotification(this);
        }

        public void GetListOfPosts()
        {
            Console.WriteLine($"Posts of {Name} by user id {Id}");
            foreach (var post in Posts)
                Console.WriteLine($"Id: {post.Id}. Description: \"{post.Description}\". When was published: {post.WhenWasPublished}");
        }
        public void UpdatePost(string description)
        {
            Console.WriteLine("You have to choose one of the posts.");
            GetListOfPosts();

            Console.Write("Id of post: ");
            int id;
            while (!Int32.TryParse(Console.ReadLine(), out id)) ;
            try
            {
                Posts.FirstOrDefault(post => post.Id == id).ChangeDescription(description);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Post with this id not found.");
                Console.WriteLine("Exception message: " + ex.Message);
            }
        }
        public void PublishPost(string description = "")
        {
            Post post = new Post(this, description);
            PublishInstagramPost.Publish(post);
            Posts.Add(post);
        }
        public void DeletePost(int id)
        {
            Posts.Remove(Posts.FirstOrDefault(post => post.Id == id));
        }
        public void Follow(User whoYouWantToFollow, bool enableAppSms = false, bool enableEmailSms = false)
        {
            Subscriptions.Add(whoYouWantToFollow);
            whoYouWantToFollow.Subscribers.Add(this);
            if (enableAppSms)
            {
                whoYouWantToFollow.PublishInstagramPost.SendMessages += AppNotification.OnSendNotifications;
                AppNotification.notificationsEnabled = true;
            }
            if (enableEmailSms)
            {
                whoYouWantToFollow.PublishInstagramPost.SendMessages += EmailOfUser.OnSendNotifications;
                EmailOfUser.notificationsEnabled = true;
            }
        }
        public void UnFollow(User whoYouWantToUnFollow)
        {
            Subscriptions.Remove(whoYouWantToUnFollow);
            whoYouWantToUnFollow.Subscribers.Remove(this);

            if (AppNotification.notificationsEnabled)
            {
                whoYouWantToUnFollow.PublishInstagramPost.SendMessages -= AppNotification.OnSendNotifications;
                AppNotification.notificationsEnabled = false;
            }
            if (EmailOfUser.notificationsEnabled)
            {
                whoYouWantToUnFollow.PublishInstagramPost.SendMessages -= EmailOfUser.OnSendNotifications;
                EmailOfUser.notificationsEnabled = false;
            }

        }
    }
}
