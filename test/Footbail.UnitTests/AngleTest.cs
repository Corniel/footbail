using NUnit.Framework;

namespace Footbail.UnitTests
{
    public class AngleTest
    {
        [TestCase(0.00, "( 0,  0)")]
        [TestCase(0.00, "( 1,  0)")]
        [TestCase(0.25, "( 1,  1)")]
        [TestCase(0.50, "( 0,  1)")]
        [TestCase(1.00, "(-1,  0)")]
        [TestCase(1.50, "( 0, -1)")]
        [TestCase(0.30406406203170144, "( 1, 1.414)")]
        public void AngleFromVelocity(double expectedPi, Velocity velocity)
        {
            var expected = Angle.Pi(expectedPi);
            Assert.AreEqual(expected, velocity.Angle);
        }
        
        [TestCase("(1, 0)", 0)]
        [TestCase("(0.8660254037844387, 0.49999999999999994)", 1d / 6d)]
        [TestCase("(0.5000000000000001, 0.86602540378443860)", 1d / 3d)]
        public void ToVelocity(Velocity expected, double angle)
        {
            var a = Angle.Pi(angle);
            var velocity = a.ToVelocity(1);
            Assert.AreEqual(expected, velocity);
        }
    }
}
