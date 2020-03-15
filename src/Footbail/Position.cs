using Footbail.Conversion;
using System;
using System.ComponentModel;

namespace Footbail
{
    /// <summary>Represents a position.</summary>
    [TypeConverter(typeof(PositionConverter))]
    public readonly struct Position : IVector, IEquatable<Position>, IFormattable
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

        /// <summary>Adds a velocity to the position.</summary>
        public Position Add(Velocity velocity) => new Position(X + velocity.X, Y + velocity.Y);
        
        /// <summary>Rounds the X- and Y-component of the position to the
        /// specified <paramref name="decimals"/>.
        /// </summary>
        public Position Round(int decimals)
        {
            var x = Math.Round(X, decimals);
            var y = Math.Round(Y, decimals);
            return new Position(x, y);
        }

        /// <inheritdoc/>
        public override string ToString() => this.ToStr();

        /// <inheritdoc/>
        public string ToString(string format, IFormatProvider formatProvider) => ToString();

        /// <inheritdoc/>
        public override bool Equals(object obj) => this.AreEqual(obj);

        /// <inheritdoc/>
        public bool Equals(Position other) => this.AreEqual(other);

        /// <inheritdoc/>
        public override int GetHashCode() => this.GetHash();

        /// <summary>Adds a velocity to the position.</summary>
        public static Position operator +(Position position, Velocity velocity) => position.Add(velocity);

        /// <summary>Parses the position.</summary>
        public static Position Parse(string str)
        {
            if (Vector.TryParse(str, out var x, out var y))
            {
                return new Position(x, y);
            }
            throw new FormatException();
        }
    }
}
