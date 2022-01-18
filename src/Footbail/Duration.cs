namespace Footbail;

/// <summary>Represents the duration of a match.</summary>
public readonly struct Duration : IEquatable<Duration>, IComparable<Duration>
{
    public static readonly int TicksPerSecond = 100;
    public static readonly int TicksPerMinute = TicksPerSecond * 60;

    /// <summary>Gets a zero duration.</summary>
    public static readonly Duration Zero;

    /// <summary>Creates a new instance of the <see cref="Duration"/> struct.</summary>
    public Duration(int ticks) => Ticks = Guard.NotNegative(ticks, nameof(ticks));

    /// <summary>Gets the number of ticks (half seconds).</summary>
    [Pure]
    public int Ticks { get; }

    /// <inheritdoc/>
    [Pure]
    public override bool Equals(object? obj) => obj is Duration other && Equals(other);

    /// <inheritdoc/>
    [Pure]
    public bool Equals(Duration other) => Ticks == other.Ticks;

    /// <inheritdoc/>
    [Pure]
    public override int GetHashCode() => Ticks;

    /// <inheritdoc/>
    [Pure]
    public int CompareTo(Duration other) => Ticks.CompareTo(other.Ticks);

    /// <summary>Represents the duration as <see cref="string"/>.</summary>
    [Pure]
    public override string ToString()
    {
        var buffer = Ticks;
        var mini = buffer % TicksPerSecond;
        buffer /= TicksPerSecond;
        var seconds = buffer % 60;
        var minutes = buffer / 60;

        return string.Format(CultureInfo.InvariantCulture, "{0}:{1:00}.{2:00}", minutes, seconds, mini);
    }

    [Pure]
    private Duration Increment() => new(Ticks + 1);
    
    [Pure]
    private Duration Decrement() => new(Ticks - 1);

    [Pure]
    private Duration Subtract(Duration other) => new(Ticks - other.Ticks);

    /// <summary>Increases the duration with 1 tick.</summary>
    public static Duration operator ++(Duration duration) => duration.Increment();
    
    /// <summary>Decreases the duration with 1 tick.</summary>
    public static Duration operator --(Duration duration) => duration.Decrement();
    
    public static Duration operator -(Duration left, Duration rigth) => left.Subtract(rigth);

    public static bool operator ==(Duration l, Duration r) => l.Equals(r);
    public static bool operator !=(Duration l, Duration r) => !(l == r);

    public static bool operator >(Duration l, Duration r) => l.CompareTo(r) > 0;
    public static bool operator <(Duration l, Duration r) => l.CompareTo(r) < 0;
    public static bool operator >=(Duration l, Duration r) => l.CompareTo(r) >= 0;
    public static bool operator <=(Duration l, Duration r) => l.CompareTo(r) <= 0;

    /// <summary>Gets the duration based on seconds.</summary>
    public static Duration FromSeconds(int seconds) => new(seconds * TicksPerSecond);

    /// <summary>Gets the duration based on minutes.</summary>
    public static Duration FromMinutes(int minutes) => new(minutes * TicksPerMinute);
}
