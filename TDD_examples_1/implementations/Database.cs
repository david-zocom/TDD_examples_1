using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_examples_1.implementations
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public interface IDatabase
    {
        List<User> GetAllUsers();
    }

    // Do not modify this class!!!
    public class Database : IDatabase
    {
        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }

    // Modify this class so it can be tested
    public class NeedsTesting
    {
        private IDatabase db;
        public NeedsTesting(IDatabase replacement)
        {
            db = replacement;
        }
        public void SetDatabase(IDatabase replacement)
        {
            db = replacement;
        }

        // To test this method, you need to
        // use Dependency Injection.
        public int CountUsers()
        {
            List<User> users = db.GetAllUsers();
            return users.Count();
        }
    }
}
