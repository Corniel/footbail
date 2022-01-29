namespace Engine_specs;

internal class Simulate
{
    [TestCase(10, 1, 9.4184, 8.8914)]
    [TestCase(10, 5, 38.8428, 6.1603)]
    [TestCase(30, 5, 84.4209, 10.4456)]
    public void Ball_moves(double initial, int seconds, double distance, double speed)
    {
        var engine = new Engine();
        var ball = new Ball(default, new Velocity(x: initial, y: 0, z: 0));
        var match = new Match(ball, new Team(TeamId.Left), new Team(TeamId.Right), Duration.FromMinutes(45), Score.Initial);
        match = engine.Simulate(match, Duration.FromSeconds(seconds));
        ball = match.Ball;
        ball.Position.Round(4).X.Should().Be(distance);
        ball.Velocity.Round(4).Speed.Should().Be(speed);
    }
}
