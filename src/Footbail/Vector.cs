namespace Footbail;

/// <summary>Helper class for shared logic on a <see cref="IVector"/>.</summary>
public static class Vector
{
    /// <summary>Returns true if the <see cref="IVector"/> equals the 
    /// <see cref="object"/>.
    /// </summary>
    public static bool AreEqual<TVector>(TVector @this, object? obj)
        where TVector : struct, IVector
        => obj is TVector other && AreEqual(@this, other);

    /// <summary>Returns true if <paramref name="this"/> <see cref="IVector"/>
    /// equals the <paramref name="other"/> <see cref="IVector"/>.
    /// </summary>
    public static bool AreEqual<TVector>(TVector @this, TVector other)
        where TVector : struct, IVector
        => @this.X == other.X && @this.Y == other.Y;

    /// <summary>Gets a hash code for the <see cref="IVector"/>.</summary>
    public static int GetHashCode(IVector @this)
        => unchecked(@this.X.GetHashCode() ^ (@this.Y.GetHashCode() * 317));

    /// <summary>Represents the <see cref="IVector"/> as a <see cref="string"/>.</summary>
    public static string ToString(IVector @this)
        => string.Format(CultureInfo.InvariantCulture, "({0}, {1})", @this.X, @this.Y);

    /// <summary>Tries to parse a <paramref name="x"/> and a <paramref name="y"/>
    /// to create an <see cref="IVector"/>.
    /// </summary>
    /// <remarks>
    /// Of the format (-?[0-9]+.[0-9]*, -?[0-9]+.[0-9], -?[0-9]+.[0-9])
    /// </remarks>
    public static bool TryParse(string? str, out double x, out double y, out double z)
    {
        x = default;
        y = default;
        z = default;

        if (!string.IsNullOrEmpty(str) && str[0] == '(' && str[^1] == ')')
        {
            var splitted = str[1..^1].Split(',');

            if (splitted.Length == 3)
            {
                return double.TryParse(splitted[0].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out x)
                    && double.TryParse(splitted[1].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out y)
                    && double.TryParse(splitted[2].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out z)
                    && IsNumber(x)
                    && IsNumber(y)
                    && IsNumber(z);
            }
        }
        return false;
    }

    private static bool IsNumber(double num) => !double.IsNaN(num) && !double.IsInfinity(num);
}
