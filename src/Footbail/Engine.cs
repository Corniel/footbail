namespace Footbail;

public sealed class Engine
{
    public Engine(Physics? physics = null) => Physics = physics ?? new Physics();

    public Physics Physics { get; }

    public Match Simulate(Match match, Duration duration)
    {
        var steps = duration;
        var simulated = match;
        while (steps > Duration.Zero)
        {
            var ball = Ball(simulated.Ball);
            simulated = simulated with { Ball = ball };
            steps--;
        }
        return simulated with { TimeLeft = simulated.TimeLeft - duration };
    }
    private Ball Ball(Ball ball)
    {
        var position = ball.Position;
        var velocity = ball.Velocity;
        
        var v = velocity.Speed;
        var Fd = Physics.Fd(Physics.Ball.Cd, Physics.Ball.A, v);
        var a = Fd / Physics.Ball.m / Duration.TicksPerSecond;
        velocity = velocity.WithSpeed(Math.Max(0, v - a));
        position += velocity / Duration.TicksPerSecond;
        
        return new(position, velocity);
    }
}
