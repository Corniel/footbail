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

            if (Physics.Pitch.OutOfPlay(ball.Position))
            {
                // TODO: ball in goal ball.Position.Y < Physics.Pitch.Goal
                // TODO: re-arrange players
                if (ball.Position.X < -Physics.Pitch.TouchLine / 2)
                {
                    simulated = simulated with { Ball = Footbail.Ball.CenterSpot, BallPlay = BallPlay.KickOff, Score = simulated.Score.RightScored() };
                }
                else if (ball.Position.X > +Physics.Pitch.TouchLine / 2)
                {
                    simulated = simulated with { Ball = Footbail.Ball.CenterSpot, BallPlay = BallPlay.KickOff, Score = simulated.Score.LeftScored() };
                }
                else if (Math.Abs(ball.Position.Z) > Physics.Pitch.GoalLine / 2)
                {
                    simulated = simulated with { Ball = ball, BallPlay = BallPlay.ThrowIn };
                }
                else
                {
                    throw new NotImplementedException();
                }
                steps = Duration.Zero;
            }
            else
            {
                simulated = simulated with { Ball = ball };
                steps--;
            }
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
