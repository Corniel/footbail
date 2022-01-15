namespace Ball_specs;

public class Move
{
    [TestCase(10, 1, 9.4245)]
    [TestCase(10, 10, 64.9302)]
    [TestCase(30, 10, 124.325)]
    public void with_default_phyics(double speed, int ticks, double distance)
    {
        var ball = new Ball(default, Angle.Zero.Velocity(speed));
        foreach(var _ in Enumerable.Range(0, ticks))
        {
            ball = ball.Move(Ball.Default);
        }
        ball.Position.Round(4).X.Should().Be(distance);
    }
}
