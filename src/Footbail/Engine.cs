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
        var possession = match.Possession;
        var left = match.Left.ToArray();
        var right = match.Right.ToArray();
        var score = match.Score;
        var left_v = Velocities(TeamId.Left, left, actions);
        var right_v = Velocities(TeamId.Right, right, actions);

        while (steps < duration && ballPlay == BallPlay.InPlay)
        {
            steps++;

            ball = Ball(ball);
            ballPlay = Physics.Pitch.OutOfPlay(ball.Position, possession);
            switch (ballPlay)
            {
                case BallPlay.InPlay:
                    ballPlay = BallPlay.InPlay;
                    Move(left, left_v);
                    Move(right, right_v);
                    break;
                case BallPlay.KickOff:
                    score = ball.Position.X < 0 ? score.RightScored() : score.LeftScored();
                    ball = Footbail.Ball.CenterSpot;
                    break;
                case BallPlay.ThrowIn:
                    // TODO: get closed by none goalkeeper
                    break;
                case BallPlay.GoalKick:
                    break;
                case BallPlay.CornerKick:
                    // TODO: get closed by none goalkeeper
                    break;
                case BallPlay.IndirectFreeKick:
                    // TODO: get closed by
                    break;
                case BallPlay.DirectFreeKick:
                    // TODO: get closed by
                    break;
                case BallPlay.PentaltyKick:
                    // TODO: get keeper
                    break;
                case BallPlay.DroppedBall:
                default: throw new NotSupportedException();
            }
        }
        return simulated with
        {
            Ball = ball,
            BallPlay = ballPlay,
            TimeLeft = simulated.TimeLeft - steps,
            Left = new(TeamId.Left, left),
            Right = new(TeamId.Right, left),
            Score = score,
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
