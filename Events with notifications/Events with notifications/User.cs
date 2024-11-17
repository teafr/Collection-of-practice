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
        public string UserName { get; private set; }
        public List<Post> Posts { get; }

        public User(int id, string name, string userName)
        {
            Id = id;
            Name = name;
            UserName = userName;
        }

        public void MakeNewPost(string description = "")
        {
            Post post = new Post(this, description);
            var publishInstagramPost = new PublishInstagramPost();
            publishInstagramPost.Publish(post);
            Posts.Add(post);
        }

        //Make DeletePost
    }
}
