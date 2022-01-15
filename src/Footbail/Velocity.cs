namespace Footbail;

/// <summary>Represents a velocity.</summary>
[TypeConverter(typeof(VelocityConverter))]
[DebuggerDisplay("{DebuggerDisplay}")]
public readonly struct Velocity : IVector, IEquatable<Velocity>
{
    public static readonly Velocity Zero;

    /// <summary>Creates a new instance of the <see cref="Velocity"/> struct.</summary>
    /// <param name="x">
    /// The X-component of the velocity.
    /// </param>
    /// <param name="y">
    /// The Y-component of the velocity.
    /// </param>
    public Velocity(double x, double y)
    {
        X = Guard.IsNumber(x, nameof(x));
        Y = Guard.IsNumber(y, nameof(y));
    }

    /// <summary>The X-component of the velocity.</summary>
    public double X { get; }

    /// <summary>The X-component of the velocity.</summary>
    public double Y { get; }

    /// <summary>Gets the speed² of the velocity.</summary>
    public double Speed2 => X * X + Y * Y;

    /// <summary>Gets the speed of the velocity.</summary>
    public double Speed => Math.Sqrt(Speed2);

    /// <summary>Gets the angle of the velocity.</summary>
    public Angle Angle => Angle.Atan2(Y, X);

    /// <summary>Rounds the X- and Y-component of the velocity to the
    /// specified <paramref name="decimals"/>.
    /// </summary>
    [Pure]
    public Velocity Round(int decimals) => new(Math.Round(X, decimals), Math.Round(Y, decimals));

    /// <summary>Gets a velocity with the same angle and specified speed.</summary>
    [Pure]
    public Velocity WithSpeed(double speed)
    {
        Guard.IsNumber(speed, nameof(speed));
        return Speed == default
            ? throw new DivideByZeroException()
            : this * (speed / Speed);
    }

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
    public bool Equals(Velocity other) => Vector.AreEqual(this, other);

    /// <inheritdoc/>
    [Pure]
    public override int GetHashCode() => Vector.GetHashCode(this);

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "Angle: {0}, Speed: {1}, ({2}, {3})", Angle, Speed, X, Y);

    /// <summary>Adds an other velocity to this velocity.</summary>
    private Velocity Add(Velocity other) => new(X + other.X, Y + other.Y);

    /// <summary>Multiplies the velocity with a factor.</summary>
    private Velocity Multiply(double factor)
    {
        Guard.IsNumber(factor, nameof(factor));
        return new Velocity(X * factor, Y * factor);
    }

    /// <summary>Adds two velocities.</summary>
    public static Velocity operator +(Velocity l, Velocity r) => l.Add(r);

    /// <summary>Multiplies the velocity with the specified factor.</summary>
    public static Velocity operator *(Velocity vector, double factor) => vector.Multiply(factor);

    /// <summary>Parses the velocity.</summary>
    [Pure]
    public static Velocity Parse(string str)
        => Vector.TryParse(str, out var x, out var y)
        ? new Velocity(x, y)
        : throw new FormatException("Not a valid velocity.");
}
