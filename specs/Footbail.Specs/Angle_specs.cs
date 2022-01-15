namespace Angle_specs;

public class To_velocity
{
    [TestCase(0, "(1, 0)")]
    [TestCase(1d / 6d, "(0.8660, 0.5000)")]
    [TestCase(1d / 3d, "(0.5000, 0.8660)")]
    public void with_speed(double angle, Velocity velocity)
        => Angle.Pi(angle).Velocity(1).Round(4).Should().Be(velocity);
}
