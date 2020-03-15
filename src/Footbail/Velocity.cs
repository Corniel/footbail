using Footbail.Conversion;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace Footbail
{
    /// <summary>Represents a velocity.</summary>
    [TypeConverter(typeof(VelocityConverter))]
    [DebuggerDisplay("{DebuggerDisplay}")]
    public readonly struct Velocity : IVector, IEquatable<Velocity>, IFormattable
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

        /// <summary>Adds an other velocity to this velocity.</summary>
        public Velocity Add(Velocity other) => new Velocity(X + other.X, Y + other.Y);

        /// <summary>Multiplies the velocity with a factor.</summary>
        public Velocity Multiply(double factor)
        {
            Guard.IsNumber(factor, nameof(factor));
            return new Velocity(X * factor, Y * factor);
        }
        
        /// <summary>Rounds the X- and Y-component of the velocity to the
        /// specified <paramref name="decimals"/>.
        /// </summary>
        public Velocity Round(int decimals)
        {
            var x = Math.Round(X, decimals);
            var y = Math.Round(Y, decimals);
            return new Velocity(x, y);
        }

        /// <summary>Gets a velocity with the same angle and specified speed.</summary>
        public Velocity WithSpeed(double speed)
        {
            Guard.IsNumber(speed, nameof(speed));

            if (Speed == default)
            {
                throw new DivideByZeroException();
            }
            return this * (speed / Speed);
        }

        /// <inheritdoc/>
        public override string ToString() => this.ToStr();

        /// <inheritdoc/>
        public string ToString(string format, IFormatProvider formatProvider) => ToString();

        /// <inheritdoc/>
        public override bool Equals(object obj) => this.AreEqual(obj);
        
        /// <inheritdoc/>
        public bool Equals(Velocity other) => this.AreEqual(other);

        /// <inheritdoc/>
        public override int GetHashCode() => this.GetHash();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
        {
            get => string.Format(CultureInfo.InvariantCulture, "Angle: {0}, Speed: {1}, ({2}, {3})", Angle, Speed, X, Y);
        }

        /// <summary>Adds two velocities.</summary>
        public static Velocity operator +(Velocity l, Velocity r) => l.Add(r);

        /// <summary>Multiplies the velocity with the specified factor.</summary>
        public static Velocity operator *(Velocity vector, double factor) => vector.Multiply(factor);

        /// <summary>Parses the velocity.</summary>
        public static Velocity Parse(string str)
        {
            if(Vector.TryParse(str, out var x, out var y))
            {
                return new Velocity(x, y);
            }
            throw new FormatException();
        }
    }
}
