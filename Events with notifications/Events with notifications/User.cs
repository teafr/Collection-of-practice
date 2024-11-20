using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private int countOfCreatedPosts = 0;

        public User(int id, string name)
        {
            Id = id;
            Name = name;
            EmailOfUser = new Email(this);
            AppNotification = new AppNotification(this);
        }

        public void GetListOfPosts()
        {
            Console.WriteLine($"Posts of {Name} by id {Id}");
            foreach (var post in Posts)
                Console.WriteLine($"Description: {post.Description}. When was published: {post.WhenWasPublished}");
        }
        public void PublishPost(string description = "")
        {
            Post post = new Post(this, description, countOfCreatedPosts);
            PublishInstagramPost.Publish(post);
            Posts.Add(post);
            countOfCreatedPosts++;
            Console.WriteLine("Post was successfully added");
        }
        public void DeletePost(Post post)
        {
            Posts.Remove(post);
            Console.WriteLine("Post was successfully removed");
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
