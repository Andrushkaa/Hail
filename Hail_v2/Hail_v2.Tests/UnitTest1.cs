using System;
using NUnit.Framework;
using NUnit;

namespace Hail_v2.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var t = Math.Sin(10);
            Assert.AreEqual(1, 1);
        }
    }
}
