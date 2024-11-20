using System.Threading;

namespace Events_with_notifications
{
    internal class Instagram
    {
        static void Main(string[] args)
        {
            int userId = 1;

            User user = new User(userId++, "Teafr");
            User firstSubscriber = new User(userId++, "Jack");
            User secondSubscriber = new User(userId++, "Coul");

            firstSubscriber.Follow(user, true, false);
            secondSubscriber.Follow(user, true, true);

            user.PublishPost("Me with my friends");
            Console.WriteLine();

            firstSubscriber.UnFollow(user);

            user.PublishPost("Hey guys!! I missed you");
        }
    }
}