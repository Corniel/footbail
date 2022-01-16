namespace Footbail;

/// <summary>Represents a player in a football match.</summary>
public readonly struct Player
{
    /// <summary>Creates a new instance of the <see cref="Player"/> class.</summary>
    public Player(Position position, Velocity velocity)
    {
        Position = position;
        Velocity = velocity;
    }

    /// <summary>Gets the current position of the player.</summary>
    public readonly Position Position;

    /// <summary>Gets the current velocity of the player.</summary>
    public readonly Velocity Velocity;

    /// <summary>Moves the player on tick.</summary>
    [Pure]
    public Player Move(Velocity velocity)
    {
        velocity += Velocity;
        velocity /= 2 * Duration.SecondsPerTick;
        return new(Position + velocity, velocity);
    }

    /// <summary>Represents the player as a <see cref="string"/>.</summary>
    [Pure]
    public override string ToString()
        => string.Format(
            CultureInfo.InvariantCulture,
            "Position: {0}, Velocity: {1}",
            Position,
            Velocity);
}
