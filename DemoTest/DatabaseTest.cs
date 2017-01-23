using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_examples_1.implementations;

namespace DemoTest
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void CountUsers_CorrectNumberOfUsers()
        {
            FakeDatabase db = new FakeDatabase();
            NeedsTesting nt = new NeedsTesting(db);

            int actual = nt.CountUsers();
            Assert.AreEqual(0, actual,
                "Wrong number of users, should be 0, is "+actual);
            Assert.AreEqual(1, db.NumberOfCalls, "Wrong number of calls");

            db.Users.Add(new User());
            db.Users.Add(new User());
            db.Users.Add(new User());
            actual = nt.CountUsers();
            Assert.AreEqual(3, actual,
                "Wrong number of users, should be 3, is " + actual);
            Assert.AreEqual(2, db.NumberOfCalls, "Wrong number of calls");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CountUsers_ExceptionIfDbNull()
        {
            NeedsTesting nt = new NeedsTesting(null);
            nt.CountUsers();
        }
    }

    public class FakeDatabase : IDatabase
    {
        public List<User> Users { get; set; }
        public int NumberOfCalls { get; set; }

        public FakeDatabase()
        {
            Users = new List<User>();
            NumberOfCalls = 0;
        }

        public List<User> GetAllUsers()
        {
            NumberOfCalls++;
            return Users;
        }
    }
}
