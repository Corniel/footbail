using System;
using System.Globalization;

namespace Footbail
{
    /// <summary>Helper class for shared logic on a <see cref="IVector"/>.</summary>
    public static class Vector
    {
        /// <summary>Returns true if the <see cref="IVector"/> equals the 
        /// <see cref="object"/>.
        /// </summary>
        public static bool AreEqual<TVector>(this TVector @this, object obj)
            where TVector : struct, IVector
        {
            return obj is TVector other && AreEqual(@this, other);
        }

        /// <summary>Returns true if <paramref name="this"/> <see cref="IVector"/>
        /// equals the <paramref name="other"/> <see cref="IVector"/>.
        /// </summary>
        public static bool AreEqual<TVector>(this TVector @this, TVector other)
            where TVector : struct, IVector
        {
            return @this.X == other.X && @this.Y == other.Y;
        }

        /// <summary>Gets a hash code for the <see cref="IVector"/>.</summary>
        public static int GetHash(this IVector @this)
        {
            return unchecked(@this.X.GetHashCode() ^ (@this.Y.GetHashCode() * 317));
        }

        /// <summary>Represents the <see cref="IVector"/> as a <see cref="string"/>.</summary>
        public static string ToStr(this IVector @this)
        {
            return string.Format(CultureInfo.InvariantCulture, "({0}, {1})", @this.X, @this.Y);
        }

        /// <summary>Tries to parse a <paramref name="x"/> and a <paramref name="y"/>
        /// to create an <see cref="IVector"/>.
        /// </summary>
        /// <remarks>
        /// Of the format (-?[0-9]+.[0-9]*, -?[0-9]+.[0-9])
        /// </remarks>
        public static bool TryParse(string str, out double x, out double y)
        {
            x = default;
            y = default;

            if (!string.IsNullOrEmpty(str) && str[0] == '(' && str[str.Length -1] == ')')
            {
                var splitted = str.Substring(1, str.Length - 2).Split(',');

                if (splitted.Length == 2)
                {
                    return double.TryParse(splitted[0].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out x)
                        && double.TryParse(splitted[1].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out y)
                        && IsNumber(x)
                        && IsNumber(y);
                }
            }
            return false;
        }

        private static bool IsNumber(double num) => !double.IsNaN(num) && !double.IsInfinity(num);
    }
}
