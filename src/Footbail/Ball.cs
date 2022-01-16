namespace Footbail;

/// <summary>Represents the ball in a football match.</summary>
public readonly partial struct Ball
{
    /// <summary>Creates a new instance of the <see cref="Ball"/> class.</summary>
    public Ball(Position position, Velocity velocity)
    {
        Position = position;
        Velocity = velocity;
    }

    /// <summary>Gets the current position of the ball.</summary>
    public readonly Position Position;

    /// <summary>Gets the current velocity of the ball.</summary>
    public readonly Velocity Velocity;

    /// <summary>Moves the ball on tick (half a second) based on the physics.</summary>
    [Pure]
    public Ball Move(Physics physics)
    {
        const int steps = 10;
        var fraction = Duration.SecondsPerTick * steps;
        var position = Position + Velocity / fraction;
        var velocity = Velocity;

        for (var step = 1; step < steps; step++)
        {
            var v = velocity.Speed;
            var Fd = physics.Fd(v);
            var a = Fd / physics.m;
            var v_min = a / fraction;
            velocity = velocity.WithSpeed(Math.Max(0, v - v_min));
            position += velocity / fraction;
        }
        return new(position, velocity);
    }

    /// <summary>Represents the ball as a <see cref="string"/>.</summary>
    [Pure]
    public override string ToString()
        => string.Format(
            CultureInfo.InvariantCulture,
            "Position: {0}, Velocity: {1}",
            Position,
            Velocity);
}
