namespace Position_specs;

public class Can_be_parsed
{
    [TestCase("(3, 4)", 3, 4)]
    [TestCase("(-13.785, +415.09)", -13.785, +415.09)]
    public void from_string(string str, double x, double y)
        => Position.Parse(str).Should().Be(new Position(x, y));
}

public class Can_be_adjusted
{
    [TestCase("(4,  3)", "( 4,   3  )", "(8,    6  )")]
    [TestCase("(4, -2)", "(-2,   1  )", "(2,   -1  )")]
    [TestCase("(3, 29)", "( 0.5, 0  )", "(3.5, 29  )")]
    [TestCase("(4, -2)", "( 0,  -0.5)", "(4,   -2.5)")]
    public void by_adding_velocity(Position position, Velocity velocity, Position adjusted)
        => (position + velocity).Should().Be(adjusted);

    [TestCase(0, "(3, 3)")]
    [TestCase(1, "(3.1, 2.7)")]
    [TestCase(2, "(3.14, 2.72)")]
    [TestCase(3, "(3.142, 2.718)")]
    [TestCase(4, "(3.1416, 2.7183)")]
    public void by_rounding(int decimals, Position rounded)
        => new Position(Math.PI, Math.E).Round(decimals).Should().Be(rounded);
}
