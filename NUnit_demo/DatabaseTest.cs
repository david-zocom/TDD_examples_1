using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TDD_examples_1.implementations;

namespace NUnit_demo
{
    [TestFixture]
    public class DatabaseTest2
    {
        [Test]
        public void CountUsers_UsesDatabase()
        {
            var mock = new Mock<IDatabase>();
            mock.Setup(x => x.GetAllUsers()).Returns(
                new List<User>());
            IDatabase db = mock.Object;
            NeedsTesting nt = new NeedsTesting(db);

            int count = nt.CountUsers();
            Assert.That(count, Is.EqualTo(0));


            mock.Verify((IDatabase x) => x.GetAllUsers(),
                Times.Exactly(1));
        }

        [Test]
        public void TestIt()
        {
            var mock = new Mock<IExampleIt>();
            mock.Setup(x => x.Example(1, "hej")).Returns(true);
            NeedsTesting2 nt = new NeedsTesting2();
            nt.Example = mock.Object;

            nt.SomeMEthod();
            mock.Verify(x => x.Example(It.IsAny<int>(),
                It.IsNotNull<string>()),
                Times.AtLeastOnce());
        }
    }
    public class NeedsTesting2
    {
        public IExampleIt Example { get; set; }
        public void SomeMEthod()
        {
            Example.Example(5, "hej");
        }
    }
    public interface IExampleIt
    {
        bool Example(int a, string b);
    }
}
