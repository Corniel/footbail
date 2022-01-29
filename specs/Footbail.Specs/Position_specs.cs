namespace Position_specs;

public class Can_be_parsed
{
    [TestCase("(3, 4, 5)", 3, 4, 5)]
    [TestCase("(-13.785, +415.09, 32)", -13.785, +415.09, 23)]
    public void from_string(string str, double x, double y, double z)
        => Position.Parse(str).Should().Be(new Position(x, y, z));
}

public class Can_be_adjusted
{
    [TestCase("(4, 0,  3)", "( 4,   1,  3  )", "(8,   1,  6  )")]
    [TestCase("(4, 0, -2)", "(-2,   1,  1  )", "(2,   1, -1  )")]
    [TestCase("(3, 0, 29)", "( 0.5, 1,  0  )", "(3.5, 1, 29  )")]
    [TestCase("(4, 0, -2)", "( 0,   1, -0.5)", "(4,   1, -2.5)")]
    public void by_adding_velocity(Position position, Velocity velocity, Position adjusted)
        => (position + velocity).Should().Be(adjusted);

    [TestCase(0, "(3, 3, 1)")]
    [TestCase(1, "(3.1, 2.7, 1.2)")]
    [TestCase(2, "(3.14, 2.72, 1.23)")]
    [TestCase(3, "(3.142, 2.718, 1.235)")]
    [TestCase(4, "(3.1416, 2.7183, 1.2346)")]
    public void by_rounding(int decimals, Position rounded)
        => new Position(Math.PI, Math.E, 1.23456789).Round(decimals).Should().Be(rounded);
}
