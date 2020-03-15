using NUnit.Framework;

namespace Footbail.UnitTests
{
    public class FootballPitchTest
    {
        [TestCase(false, "(15, 4)", "not out-of-play")]
        [TestCase(true, "(15, -34.1)", "Below")]
        [TestCase(true, "(15, +34.1)", "Above")]
        [TestCase(true, "(-53, +33)", "Left")]
        [TestCase(true, "(+53, +33)", "Right")]
        public void OutOfPlay(bool expected, Position position, string message)
        {
            var pitch = new FootballPitch(touchLine: 105, goalLine: 68);
            var outOfPlay = pitch.OutOfPlay(position);
            Assert.AreEqual(expected, outOfPlay, message);
        }
    }
}
