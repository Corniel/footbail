using NUnit.Framework;

namespace Footbail.UnitTests
{
    public class VectorTest
    {
        [Test]
        public void Parse_3Comma4_X3Y4()
        {
            var parsed = Velocity.Parse("(3, 4)");
            var expected = new Velocity(3, 4);

            Assert.AreEqual(expected, parsed);
        }

        [TestCase("(4,  3)", +2.0, "(  8,  6)")]
        [TestCase("(4, -2)", +0.5, "(  2, -1)")]
        [TestCase("(3, 29)", +0.0, "(  0,  0)")]
        [TestCase("(4, -2)", -5.0, "(-20, 10)")]
        public void Multiply(Velocity velocity, double factor, Velocity expected)
        {
            var multiplied = velocity * factor;
            Assert.AreEqual(expected, multiplied);
        }
    }
}
