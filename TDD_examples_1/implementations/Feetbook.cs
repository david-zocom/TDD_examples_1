using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1.implementations
{
    // TODO: Test and implement this
    public class UserManager
    {
        // Attempts to log in a user
        bool loginUser(string username, string plaintextPassword)
        {
            throw new NotImplementedException();
        }
        public void logoutUser()
        {
            throw new NotImplementedException();
        }
        // Saves a new pair of feet on *Feetbook* and returns a Post object
        public Post createNewFeetpost(string imageUrl, Comment c)
        {
            throw new NotImplementedException();
        }
        // Returns all posts made by a specific user, or all posts if the username is blank
        public List<Post> getPosts(string username)
        {
            throw new NotImplementedException();
        }
        // Returns all comments on *Feetbook* for a specific post
        // The Post object can be different from what is stored in the database
        // TODO: What should I do if a post doesn't exist?
        public List<Comment> getCommentsForPost(Post post)
        {
            throw new NotImplementedException();
        }
    }

    // TODO: test and implement this later
    // Remember to avoid using this class when testing UserManager
    public class EncryptionManager
    {
        // Encrypts a plaintext password string so we can later store it in the database
        public string encryptPassword(string plaintextPassword)
        {
            throw new NotImplementedException();
        }
        // Returns true if "username" is an existing user and the encrypted passwords match
        public bool loginUser(String username, string encryptedPassword)
        {
            throw new NotImplementedException();
        }
    }
    
    // No logic in Post and Comment, we don't need to test them
    public class Post
    {
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
}
