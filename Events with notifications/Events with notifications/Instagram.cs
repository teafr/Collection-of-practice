using System.Threading;

namespace Events_with_notifications
{
    internal class Instagram
    {
        static void Main(string[] args)
        {
            User user = new User(1, "Teafr", "teafr");
            user.MakeNewPost();
            PublishInstagramPost publishNewPostInInstagra = new PublishInstagramPost();
            EmailNotification emailMessage = new();
            AppNotification appMessage = new();

            publishNewPostInInstagra.SendMessages += emailMessage.OnSendNotifications;
            publishNewPostInInstagra.SendMessages += appMessage.OnSendNotifications;

            publishNewPostInInstagra.Publish(post);
        }
    }
}