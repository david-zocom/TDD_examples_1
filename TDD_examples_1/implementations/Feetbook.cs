using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1.implementations
{
    // TODO: Test and implement this now
    public class UserManager
    {
        public IEncryptionManager em { get; set; }
        public bool UserIsLoggedIn { get; private set; } = false;
        private List<Post> allPosts = new List<Post>();
        // TODO: använd HashSet<string> eller databas så vi
        // kan skilja på användare

        public bool safeLoginUser(string username, string plaintextPassword)
        {
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(plaintextPassword))
                throw new Exception();
            string encrypted = em.encryptPassword(plaintextPassword);
            bool result = em.loginUser(username, encrypted);
            UserIsLoggedIn = result;
            return result;
        }
        public void logoutUser()
        {
            UserIsLoggedIn = false;
        }
        public Post createNewFeetpost(string imageUrl, Comment c)
        {
            if (string.IsNullOrEmpty(imageUrl) || c == null)
                throw new Exception();
            if (UserIsLoggedIn)
            {
                Post p = new Post();
                allPosts.Add(p);
                return p;
            }
            else
                return null;
        }
        public List<Post> getPosts(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new Exception("Bad user name");
            if (!UserIsLoggedIn)
                throw new Exception("User is not logged in");
            return allPosts;
        }
        public List<Comment> getCommentsForPost(Post post)
        {
            if (post == null)
                throw new Exception();
            if (!UserIsLoggedIn)
                throw new Exception();
            return post.Comments;
        }
    }

    // TODO: test and implement this later
    // Remember to avoid using this class directly when
    // testing UserManager
    public class EncryptionManager : IEncryptionManager
    {
        public string encryptPassword(string plaintextPassword)
        {
            throw new NotImplementedException();
        }
        public bool loginUser(String username, string encryptedPassword)
        {
            throw new NotImplementedException();
        }
    }

    // No logic in Post and Comment, we don't need to test them
    public class Post
    {
        public Post()
        {
            Comments = new List<Comment>();
        }
        public User Author { get; set; }
        public string ImageUrl { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime Timestamp { get; set; }
    }
    public class Comment
    {
        public Post ParentPost { get; set; }
        public string TextContent { get; set; }
        public DateTime Timestamp { get; set; }
    }
    //public class User { }
}
