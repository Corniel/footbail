using NUnit.Framework;

namespace Footbail.UnitTests
{
    public class DurationTest
    {
        [TestCase("0:25.0", 50)]
        [TestCase("0:05.5", 11)]
        [TestCase("32:30.0", 3900)]
        [TestCase("32:31.5", 3903)]
        public void ToString(string expected, int ticks)
        {
            var duration = new Duration(ticks);
            var formatted = duration.ToString();

            Assert.AreEqual(expected, formatted);
        }
    }
}
