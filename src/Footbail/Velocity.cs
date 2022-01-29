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
    /// <param name="z">
    /// The Z-component of the velocity.
    /// </param>
    public Velocity(double x, double y, double z)
    {
        X = Guard.IsNumber(x, nameof(x));
        Y = Guard.IsNumber(y, nameof(y));
        Z = Guard.IsNumber(z, nameof(z));
    }

    /// <summary>The X-component of the velocity.</summary>
    public double X { get; }

    /// <summary>The X-component of the velocity.</summary>
    public double Y { get; }

    /// <summary>The X-component of the velocity.</summary>
    public double Z { get; }

    /// <summary>Gets the speed² of the velocity.</summary>
    public double Speed2 => X.Pow2() + Y.Pow2() + Z.Pow2();

    /// <summary>Gets the speed of the velocity.</summary>
    public double Speed => Math.Sqrt(Speed2);

    /// <summary>Rounds the X- and Y-component of the velocity to the
    /// specified <paramref name="decimals"/>.
    /// </summary>
    [Pure]
    public Velocity Round(int decimals)
        => new(
            Math.Round(X, decimals),
            Math.Round(Y, decimals),
            Math.Round(Z, decimals));

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
    private string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "Speed: {0}, ({1}, {2}, {3})", Speed, X, Y, Z);

    /// <summary>Adds an other velocity to this velocity.</summary>
    private Velocity Add(Velocity other) => new(X + other.X, Y + other.Y, Z + other.Z);

    /// <summary>Multiplies the velocity with a factor.</summary>
    private Velocity Multiply(double factor)
    {
        Guard.IsNumber(factor, nameof(factor));
        return new Velocity(X * factor, Y * factor, Z * factor);
    }
    /// <summary>Multiplies the velocity with a factor.</summary>
    private Velocity Divide(double factor)
    {
        Guard.IsNumber(factor, nameof(factor));
        if (factor == default) throw new DivideByZeroException();
        return new Velocity(X / factor, Y / factor, Z / factor);
    }

    /// <summary>Adds two velocities.</summary>
    public static Velocity operator +(Velocity l, Velocity r) => l.Add(r);

    /// <summary>Multiplies the velocity with the specified factor.</summary>
    public static Velocity operator *(Velocity vector, double factor) => vector.Multiply(factor);

    /// <summary>Divides the velocity with the specified factor.</summary>
    public static Velocity operator /(Velocity vector, double factor) => vector.Divide(factor);

    public static bool operator ==(Velocity left, Velocity right) => left.Equals(right);

    public static bool operator !=(Velocity left, Velocity right) => !(left == right);

    /// <summary>Parses the velocity.</summary>
    [Pure]
    public static Velocity Parse(string? str)
        => Vector.TryParse(str, out var x, out var y, out var z)
        ? new Velocity(x, y, z)
        : throw new FormatException("Not a valid velocity.");
}
