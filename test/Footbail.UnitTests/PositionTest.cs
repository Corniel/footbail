using NUnit.Framework;

namespace Footbail.UnitTests
{
    public class PositionTest
    {
        [Test]
        public void Parse_3Comma4_X3Y4()
        {
            var parsed = Position.Parse("(3, 4)");
            var expected = new Position(3, 4);

            Assert.AreEqual(expected, parsed);
        }


        [TestCase("(4,  3)", "( 4,   3  )", "(8,    6  )")]
        [TestCase("(4, -2)", "(-2,   1  )", "(2,   -1  )")]
        [TestCase("(3, 29)", "( 0.5, 0  )", "(3.5, 29  )")]
        [TestCase("(4, -2)", "( 0,  -0.5)", "(4,   -2.5)")]
        public void Add(Position position, Velocity velocity, Position expected)
        {
            var multiplied = position + velocity;
            Assert.AreEqual(expected, multiplied);
        }
    }
}
