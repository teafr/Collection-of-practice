using Events_with_notifications.Models;
using System.Threading;

namespace Events_with_notifications
{
    internal class Instagram
    {
        static void Main(string[] args)
        {
            User firstUser = new User("Teafr");
            User secondUser = new User( "Jack");
            User thirdUser = new User("Coul");
            User fourthUser = new User("Saul");

            secondUser.Follow(firstUser, true);
            thirdUser.Follow(firstUser, true, true);

            firstUser.PublishPost("Me with my friends");
            Console.WriteLine();

            fourthUser.Follow(secondUser);
            secondUser.UnFollow(firstUser);

            firstUser.PublishPost("Hey guys!! I missed you");
            Console.WriteLine();
            secondUser.PublishPost("Hell");
            Console.WriteLine();
            firstUser.PublishPost("Yummy!!");
            Console.WriteLine();

            thirdUser.Follow(secondUser, false, true);

            secondUser.PublishPost("In the forest");
            Console.WriteLine();

            firstUser.DeletePost(1);
            secondUser.UpdatePost("It was so hard");

            firstUser.GetListOfPosts();
            secondUser.GetListOfPosts();
        }
    }
}