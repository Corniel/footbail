namespace Footbail;

/// <summary>Represents a position.</summary>
[TypeConverter(typeof(PositionConverter))]
public readonly struct Position : IVector, IEquatable<Position>
{
    /// <summary>The center (0, 0) position.</summary>
    public static readonly Position Center;

    /// <summary>Creates a new instance of the <see cref="Position"/> struct.</summary>
    /// <param name="x">
    /// The X-component of the position.
    /// </param>
    /// <param name="y">
    /// The Y-component of the position.
    /// </param>
    public Position(double x, double y)
    {
        X = Guard.IsNumber(x, nameof(x));
        Y = Guard.IsNumber(y, nameof(y));
    }

    /// <summary>The X-component of the position.</summary>
    public double X { get; }

    /// <summary>The X-component of the position.</summary>
    public double Y { get; }

    /// <summary>Rounds the X- and Y-component of the position to the
    /// specified <paramref name="decimals"/>.
    /// </summary>
    [Pure]
    public Position Round(int decimals) => new(Math.Round(X, decimals), Math.Round(Y, decimals));

    /// <inheritdoc/>
    [Pure]
    public override string ToString() => Vector.ToString(this);

    /// <inheritdoc/>
    /// <remarks>Required for <see cref="TypeConverter"/>.</remarks>
    [Pure]
    public string ToString(string? format, IFormatProvider? formatProvider) => ToString();

    /// <inheritdoc/>
    [Pure]
    public override bool Equals(object? obj) => Vector.AreEqual(this, obj);

    /// <inheritdoc/>
    [Pure]
    public bool Equals(Position other) => Vector.AreEqual(this, other);

    /// <inheritdoc/>
    [Pure]
    public override int GetHashCode() => Vector.GetHashCode(this);

    /// <summary>Adds a velocity to the position.</summary>
    [Pure]
    private Position Add(Velocity velocity) => new(X + velocity.X, Y + velocity.Y);

    /// <summary>Returns true if both positions are equal.</summary>
    public static bool operator ==(Position left, Position right) => left.Equals(right);

    /// <summary>Returns false if both positions are equal.</summary>
    public static bool operator !=(Position left, Position right) => !(left == right);

    /// <summary>Adds a velocity to the position.</summary>
    public static Position operator +(Position position, Velocity velocity) => position.Add(velocity);

    /// <summary>Parses the position.</summary>
    [Pure]
    public static Position Parse(string str)
        => Vector.TryParse(str, out var x, out var y)
        ? new Position(x, y)
        : throw new FormatException("Not a valid position");

}
