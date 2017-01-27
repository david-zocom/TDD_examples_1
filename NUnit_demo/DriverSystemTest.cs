using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TDD_examples_1.implementations;

namespace NUnit_demo
{
    [TestFixture]
    public class DriverSystemTest
    {
        private DriverSystem ds;

        [SetUp]
        public void Setup()
        {
            ds = new DriverSystem();
        }


        [Test]
        [TestCase(null, 50)]
        [TestCase("", 50)]
        [TestCase("qwerty", 50)]
        [TestCase("B", -1)]
        [TestCase("B", int.MinValue)]
        public void CanGet_IncorrectParameters(string a, int b)
        {
            Assert.That(() => ds.CanGet(a, b),
                Throws.TypeOf<Exception>());
        }

        [Test]
        public void CanGet_TooYoung_False()
        {
            Assert.That(() => ds.CanGet("B", 17), Is.False);
            Assert.That(ds.CanGet("B", 0), Is.False,
                "inte ok att ta B-körkort vid 0 års ålder");
            Assert.That(ds.CanGet("C", 20), Is.False);
            Assert.That(ds.CanGet("C", 0), Is.False);
        }

        [Test]
        public void CanGet_Success_True()
        {
            Assert.That(ds.CanGet("B", 18), Is.True);
            Assert.That(ds.CanGet("B", int.MaxValue), Is.True);
            Assert.That(ds.CanGet("C", 21), Is.True);
            Assert.That(ds.CanGet("C", int.MaxValue), Is.True);
        }

        [Test]
        public void SetSpeedLimit_InvalidValue_Throws()
        {
            Assert.That(() => ds.SetSpeedLimit(0),
                Throws.TypeOf<BadSpeedException>());
            Assert.That(() => ds.SetSpeedLimit(201),
                Throws.TypeOf<BadSpeedException>());
        }

        [Test]
        [TestCase(1)]
        [TestCase(200)]
        public void SetSpeedLimit_Success(int x)
        {
            ds.SetSpeedLimit(x);
            Assert.That(ds.SpeedLimit, Is.EqualTo(x));
        }


        [Test]
        public void IsSpeeding_InvalidSpeed_Throws()
        {
            ds.SetSpeedLimit(50);
            Assert.That(() => ds.IsSpeeding(-1),
                Throws.TypeOf<BadSpeedException>());
            Assert.That(() => ds.IsSpeeding(int.MinValue),
                Throws.TypeOf<BadSpeedException>());
        }
        [Test]
        public void IsSpeeding_LimitNotSet_Throws()
        {
            Assert.That(() => ds.IsSpeeding(50),
                Throws.TypeOf<NullReferenceException>());
        }
        [Test]
        public void IsSpeeding_True()
        {
            ds.SetSpeedLimit(30);
            Assert.That(ds.IsSpeeding(31), Is.True);
            Assert.That(ds.IsSpeeding(95), Is.True);
        }
        [Test]
        public void IsSpeeding_False()
        {
            ds.SetSpeedLimit(190);
            Assert.That(ds.IsSpeeding(190), Is.False);
            Assert.That(ds.IsSpeeding(57), Is.False);
        }
    }
}
