using Footbail.Actions;

namespace Footbail;

public sealed class Engine
{
    public Engine(Physics? physics = null) => Physics = physics ?? new Physics();

    public Physics Physics { get; }

    public Match Simulate(Match match, IReadOnlyCollection<PlayerAction> actions, Duration duration)
    {
        var steps = Duration.Zero;
        var simulated = match;
        var ball = match.Ball;
        var ballPlay = BallPlay.InPlay;
        var left = match.Left.ToArray();
        var right = match.Right.ToArray();
        var left_v = Velocities(TeamId.Left, left, actions);
        var right_v = Velocities(TeamId.Right, right, actions);

        while (steps < duration && ballPlay == BallPlay.InPlay)
        {
            steps++;

            ball = Ball(ball);

            if (Physics.Pitch.OutOfPlay(ball.Position))
            {
                // TODO: ball in goal ball.Position.Y < Physics.Pitch.Goal
                // TODO: re-arrange players
                if (ball.Position.X < -Physics.Pitch.TouchLine / 2)
                {
                    ball = Footbail.Ball.CenterSpot;
                    ballPlay = BallPlay.KickOff;
                    simulated = simulated with { Score = simulated.Score.RightScored() };
                }
                else if (ball.Position.X > +Physics.Pitch.TouchLine / 2)
                {
                    ball = Footbail.Ball.CenterSpot;
                    ballPlay = BallPlay.KickOff;
                    simulated = simulated with { Score = simulated.Score.LeftScored() };
                }
                else if (Math.Abs(ball.Position.Z) > Physics.Pitch.GoalLine / 2)
                {
                    ballPlay = BallPlay.ThrowIn;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                ballPlay = BallPlay.InPlay;
                Move(left, left_v);
                Move(right, right_v);
            }
        }
        return simulated with
        {
            Ball = ball,
            BallPlay = ballPlay,
            TimeLeft = simulated.TimeLeft - steps,
            Left = new(TeamId.Left, left),
            Right = new(TeamId.Right, left),
        };
    }

    private static Velocity[] Velocities(TeamId team, Player[] players, IReadOnlyCollection<PlayerAction> actions)
        => players
        .Select((_, index) => actions
            .OfType<Move>()
            .FirstOrDefault(m => m.Team == team && m.Number == index + 1)?
            .Velocity ?? Velocity.Zero)
        .ToArray();

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

    private static void Move(Player[] players, Velocity[] velocities)
    {
        for (var index = 0; index < players.Length; index++)
        {
            players[index] = Move(players[index], velocities[index]);
        }
    }

    private static Player Move(Player player, Velocity velocity)
    {
        velocity += player.Velocity;
        velocity /= 2 * Duration.TicksPerSecond;
        return new(player.Position + velocity, velocity);
    }
}
