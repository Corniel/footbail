namespace Duration_specs;

public class Has_custom_string_representation
{
    [TestCase("0:25.00", 2500)]
    [TestCase("0:05.50", 550)]
    [TestCase("32:30.00", 195000)]
    [TestCase("32:31.57", 195157)]
    public void ToString(string formatted, int ticks)
        => new Duration(ticks).ToString().Should().Be(formatted);
}
