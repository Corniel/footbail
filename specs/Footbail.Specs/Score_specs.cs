namespace Score_specs;

public class Has_custom_string_representation
{
    [TestCase(0, 0, "0-0")]
    [TestCase(3, 0, "3-0")]
    [TestCase(0, 9, "0-9")]
    public void for_score(int l, int r, string formatted)
        => new Score(l, r).ToString().Should().Be(formatted);
}

public class Can_be_adjusted
{
    [Test]
    public void Left_scored()
        => new Score(0, 3).LeftScored().Should().Be(new Score(1, 3));

    [Test]
    public void Right_scored()
        => new Score(0, 3).RightScored().Should().Be(new Score(0, 4));
}
