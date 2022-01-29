using static Footbail.Physics;

namespace Pitch_specs;

public class Out_of_play
{
    [TestCase(false, "(52.5, 0, 34)", "not out-of-play")]
    [TestCase(true, "(15, 0, -34.1)", "Below")]
    [TestCase(true, "(15, 0, +34.1)", "Above")]
    [TestCase(true, "(-53, 0, +33)", "Left")]
    [TestCase(true, "(+53, 0, +33)", "Right")]
    public void OutOfPlay(bool outOfPlay, Position position, string message)
        => PitchPhysics.FIFA.OutOfPlay(position).Should().Be(outOfPlay, because: message);
}
