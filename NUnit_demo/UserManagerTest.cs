using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TDD_examples_1.implementations;
using Moq;

namespace NUnit_demo
{
    public class UserManagerTest
    {
        private string username, password;
        private UserManager um;
        private Mock<IEncryptionManager> mockEM;
        private string url;
        private Comment comment;


        public UserManagerTest()
        {
            username = "David";
            password = "password";
            um = new UserManager();
            mockEM = new Mock<IEncryptionManager>();
            um.em = mockEM.Object;
            url = "wrngjkenjkgndf";
            comment = new Comment();
        }

        [Fact]
        public void loginUser_InvalidValues_Throws()
        {
            Assert.Throws<Exception>(() =>
                um.safeLoginUser(null, password));
            Assert.Throws<Exception>(() =>
                um.safeLoginUser(username, null));
            Assert.Throws<Exception>(() =>
                um.safeLoginUser("", password));
            Assert.Throws<Exception>(() =>
                um.safeLoginUser(username, ""));
        }

        [Fact]
        public void loginUser_WrongUsernameOrPassword_False()
        {
            bool result = um.safeLoginUser(username, password + "1");
            Assert.Equal(false, result);
            mockEM.Verify(x => x.loginUser(It.IsAny<string>(),
                It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void loginUser_CorrectUsernnameAndPassword_True()
        {
            /*mockEM.Setup(x => x.loginUser(username, password))
                .Returns(true);*/
            mockEM.Setup(x => x.loginUser(It.IsAny<string>(),
                It.IsAny<string>()))
                .Returns(true);
            bool result = um.safeLoginUser(username, password);
            Assert.Equal(true, result);
            mockEM.Verify(x => x.loginUser(
                It.IsAny<string>(),//It.Is<string>(y => y == username), 
                It.IsAny<string>()),//It.Is<string>(z => z == password)),
                Times.Once());
        }

        [Fact]
        public void logoutUser_LoggedIn_Success()
        {
            um.safeLoginUser(username, password);
            um.logoutUser();
            Assert.Equal(false, um.UserIsLoggedIn);
        }
        [Fact]
        public void logoutUser_NotLoggedIn_Fail()
        {
            um.logoutUser();
            Assert.Equal(false, um.UserIsLoggedIn);
        }


        [Fact]
        public void createFeetPost_InvalidValues_Throws()
        {
            url = "wrngjkenjkgndf";
            comment = new Comment();
            Assert.Throws<Exception>(
                () => um.createNewFeetpost(null, comment));
            Assert.Throws<Exception>(
                () => um.createNewFeetpost("", comment));
            Assert.Throws<Exception>(
                () => um.createNewFeetpost(url, null));
        }

        [Fact]
        public void createNewFeetpost_ReturnsPost()
        {
            DoLogin();
            Post post = um.createNewFeetpost(url, comment);
            Assert.NotNull(post);
        }
        private void DoLogin()
        {
            mockEM.Setup(x => x.loginUser(It.IsAny<string>(),
                It.IsAny<string>()))
                .Returns(true);
            um.safeLoginUser(username, password);

        }
        [Fact]
        public void createNewFeetpost_ReturnsNull()
        {
            Post post = um.createNewFeetpost(url, comment);
            Assert.Null(post);
        }

        [Fact]
        public void getPosts_InvalidUsername_Throws()
        {
            DoLogin();
            Assert.Throws<Exception>(() => um.getPosts(null));
            Assert.Throws<Exception>(() => um.getPosts(""));
        }
        [Fact]
        public void getPosts_NotLoggedIn_Throws()
        {
            Assert.Throws<Exception>(() => um.getPosts(username));
        }

        [Fact]
        public void getPosts_ReturnsEmptyList()
        {
            DoLogin();
            List<Post> posts = um.getPosts(username);
            Assert.NotNull(posts);
            Assert.Equal(0, posts.Count);
        }
        [Fact]
        public void getPosts_ReturnsNonEmptyList()
        {
            DoLogin();
            um.createNewFeetpost(url, comment);
            um.createNewFeetpost(url, comment);
            um.createNewFeetpost(url, comment);
            List<Post> posts = um.getPosts(username);
            Assert.NotNull(posts);
            Assert.Equal(3, posts.Count);
        }

        [Fact]
        public void getCommentsForPost_InvalidValues_Throws()
        {
            DoLogin();
            Assert.Throws<Exception>(() => um.getCommentsForPost(null));
        }
        [Fact]
        public void getCommentsForPost_NotLoggedIn_Throws()
        {
            Assert.Throws<Exception>(() => 
                um.getCommentsForPost(new Post()));
        }
        [Fact]
        public void getCommentsForPost_EmptyList()
        {
            DoLogin();
            List<Comment> comments = um.getCommentsForPost(new Post());
            Assert.NotNull(comments);
            Assert.Empty(comments);
        }
        [Fact]
        public void getCommentsForPost_NonEmptyList()
        {
            DoLogin();
            Post p = new Post();
            p.Comments = new List<Comment>();
            p.Comments.Add(new Comment());
            p.Comments.Add(new Comment());
            p.Comments.Add(new Comment());
            List<Comment> comments = um.getCommentsForPost(p);
            Assert.NotNull(comments);
            Assert.Equal(3, comments.Count);
        }
    }
}
