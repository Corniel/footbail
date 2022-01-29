namespace Velocity_specs;

public class Can_be_parsed
{
    [TestCase("(3, 4, 8)", 3, 4, 8)]
    [TestCase("(-13.785, 0.15, +415.09)", -13.785, 0.15, +415.09)]
    public void from_string(string str, double x, double y, double z)
        => Velocity.Parse(str).Should().Be(new Velocity(x, y, z));
}

public class Can_be_adjusted
{
    [TestCase("(4, 0,  3)", "( 4,   1,  3  )", "(8,  1,  6  )")]
    [TestCase("(4, 0, -2)", "(-2,   1,  1  )", "(2,  1, -1  )")]
    [TestCase("(3, 0, 29)", "( 0.5, 1,  0  )", "(3.5,1, 29  )")]
    [TestCase("(4, 0, -2)", "( 0,   1, -0.5)", "(4,  1, -2.5)")]
    public void by_adding_velocity(Velocity position, Velocity velocity, Velocity adjusted)
        => (position + velocity).Should().Be(adjusted);

    [TestCase(0, "(3, 3, 1)")]
    [TestCase(1, "(3.1, 2.7, 1.2)")]
    [TestCase(2, "(3.14, 2.72, 1.23)")]
    [TestCase(3, "(3.142, 2.718, 1.235)")]
    [TestCase(4, "(3.1416, 2.7183, 1.2346)")]
    public void by_rounding(int decimals, Velocity rounded)
        => new Velocity(Math.PI, Math.E, 1.23456789).Round(decimals).Should().Be(rounded);
}
