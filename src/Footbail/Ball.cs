namespace Footbail;

/// <summary>Represents the ball in a football match.</summary>
public readonly partial struct Ball
{
    public static readonly Ball CenterSpot;

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

    /// <summary>Represents the ball as a <see cref="string"/>.</summary>
    [Pure]
    public override string ToString()
        => string.Format(
            CultureInfo.InvariantCulture,
            "Position: {0}, Velocity: {1}",
            Position,
            Velocity);
}
