using NUnit.Framework;

namespace Footbail.UnitTests
{
    public class PitchTest
    {
        [TestCase(false, "(52.5, 34)", "not out-of-play")]
        [TestCase(true, "(15, -34.1)", "Below")]
        [TestCase(true, "(15, +34.1)", "Above")]
        [TestCase(true, "(-53, +33)", "Left")]
        [TestCase(true, "(+53, +33)", "Right")]
        public void OutOfPlay(bool expected, Position position, string message)
        {
            var pitch = Pitch.UEFA;
            var outOfPlay = pitch.OutOfPlay(position);
            Assert.AreEqual(expected, outOfPlay, message);
        }
    }
}
