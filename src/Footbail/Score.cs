namespace Footbail;

/// <summary>Represents the score of a football match.</summary>
public readonly struct Score : IEquatable<Score>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly int l;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly int r;

    /// <summary>Gets the initial (0-0) score.</summary>
    public static readonly Score Initial;

    /// <summary>Creates a new instance of the <see cref="Score"/> struct.</summary>
    public Score(int left, int right)
    {
        l = Guard.NotNegative(left, nameof(left));
        r = Guard.NotNegative(right, nameof(right));
    }

    /// <summary>Gets a new score where left scored.</summary>
    [Pure]
    public Score LeftScored() => new(l + 1, r);

    /// <summary>Gets a new score where left scored.</summary>
    [Pure]
    public Score RightScored() => new(l, r + 1);

    /// <summary>Represents the score as a <see cref="string"/>.</summary>
    [Pure]
    public override string ToString() => string.Format(CultureInfo.InvariantCulture, "{0}-{1}", l, r);

    /// <inheritdoc/>
    [Pure]
    public override bool Equals(object? obj) => obj is Score other && Equals(other);

    /// <inheritdoc/>
    [Pure]
    public bool Equals(Score other) => l == other.l && r == other.r;

    /// <inheritdoc/>
    [Pure]
    public override int GetHashCode() => unchecked(l ^ (r << 16));

    public static bool operator ==(Score left, Score right)=> left.Equals(right);
    public static bool operator !=(Score left, Score right)=> !(left == right);
}
