using Events_with_notifications.EventSystem;
using Events_with_notifications.NotificationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Events_with_notifications.Instagram;

namespace Events_with_notifications.Models
{
    public class User
    {
        private static int _currentId = 1;
        public int Id { get; }
        public string Name { get; private set; }
        public UserEmail Email { get; private set; }
        public AppNotification AppNotification { get; private set; }
        public List<Post> Posts { get; } = new List<Post>();
        public List<User> Subscribers { get; private set; } = new List<User>();
        public List<User> Subscriptions { get; private set; } = new List<User>();
        public PublishInstagramPost PublishInstagramPost { get; } = new PublishInstagramPost();

        public User(string name)
        {
            Id = _currentId++;
            Name = name;
            Email = new UserEmail(this);
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
            while (!int.TryParse(Console.ReadLine(), out id)) ;

            try
            {
                Posts.FirstOrDefault(post => post.Id == id)!.ChangeDescription(description);
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
            Posts.Remove(Posts.FirstOrDefault(post => post.Id == id)!);
        }
        public void Follow(User whoYouWantToFollow, bool enableAppSms = false, bool enableEmailSms = false)
        {
            Subscriptions.Add(whoYouWantToFollow);
            whoYouWantToFollow.Subscribers.Add(this);
            if (enableAppSms)
            {
                whoYouWantToFollow.PublishInstagramPost.SendMessages += AppNotification.OnSendNotifications!;
                AppNotification.NotificationsEnabled = true;
            }
            if (enableEmailSms)
            {
                whoYouWantToFollow.PublishInstagramPost.SendMessages += Email.OnSendNotifications!;
                Email.notificationsEnabled = true;
            }
        }
        public void UnFollow(User whoYouWantToUnFollow)
        {
            Subscriptions.Remove(whoYouWantToUnFollow);
            whoYouWantToUnFollow.Subscribers.Remove(this);

            if (AppNotification.NotificationsEnabled)
            {
                whoYouWantToUnFollow.PublishInstagramPost.SendMessages -= AppNotification.OnSendNotifications!;
                AppNotification.NotificationsEnabled = false;
            }
            if (Email.NotificationsEnabled)
            {
                whoYouWantToUnFollow.PublishInstagramPost.SendMessages -= Email.OnSendNotifications!;
                Email.notificationsEnabled = false;
            }

        }
    }
}
