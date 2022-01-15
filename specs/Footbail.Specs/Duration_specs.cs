namespace Duration_specs;

public class Has_custom_string_representation
{
    [TestCase("0:25.0", 50)]
    [TestCase("0:05.5", 11)]
    [TestCase("32:30.0", 3900)]
    [TestCase("32:31.5", 3903)]
    public void ToString(string formatted, int ticks)
        => new Duration(ticks).ToString().Should().Be(formatted);
}
