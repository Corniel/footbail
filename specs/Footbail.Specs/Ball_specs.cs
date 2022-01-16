namespace Ball_specs;

public class Move
{
    [TestCase(10, 1, 4.8564, 9.4352)]
    [TestCase(10, 2, 9.4459, 8.931)]
    [TestCase(10, 10, 39.1934, 6.2584)]
    [TestCase(30, 10, 85.6468, 10.696)]
    public void with_default_phyics(double initial, int ticks, double distance, double speed)
    {
        var ball = new Ball(default, Angle.Zero.Velocity(initial));
        foreach(var _ in Enumerable.Range(0, ticks))
        {
            ball = ball.Move(Ball.Default);
        }
        ball.Position.Round(4).X.Should().Be(distance);
        ball.Velocity.Round(4).Speed.Should().Be(speed);
    }
}
