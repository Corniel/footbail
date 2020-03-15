using System;
using System.Globalization;

namespace Footbail
{
    /// <summary>Represents a (radial) angle.</summary>
    public readonly struct Angle
    {
        /// <summary>Represents π (3.1415926535897931).</summary>
        private const double PI = Math.PI;

        /// <summary>Gets the default/zero angle.</summary>
        public static readonly Angle Zero;

        /// <summary>The underlying value.</summary>
        private readonly double value;

        /// <summary>Creates a new instance of the <see cref="Angle"/> struct.</summary>
        private Angle(double angle) => value = angle;

        /// <summary>Creates a velocity from the angle with the specified speed.</summary>
        public Velocity ToVelocity(double speed)
        {
            Guard.IsNumber(speed, nameof(speed));

            var x = Math.Cos(value);
            var y = Math.Sin(value);

            return new Velocity(x * speed, y * speed);
        }

        /// <summary>Adds an angle to the current angle.</summary>
        public Angle Add(Angle other)
        {
            return new Angle(value + other.value);
        }

        /// <summary>Represents the angle as a <see cref="string"/>.</summary>
        public override string ToString() => (value / PI).ToString(CultureInfo.InvariantCulture) + 'π';

        /// <summary>Adds two angles.</summary>
        public static Angle operator +(Angle left, Angle right) => left.Add(right);

        /// <summary>Creates an angle specified as a fraction of π.</summary>
        public static Angle Pi(double fraction) => new Angle(Guard.IsNumber(fraction, nameof(fraction)) * PI);

        /// <summary>Returns the angle whose tangent is the quotient of two specified numbers.</summary>
        public static Angle Atan2(double y, double x)
        {
            Guard.IsNumber(y, nameof(y));
            Guard.IsNumber(x, nameof(x));

            var angle = Math.Atan2(y, x);
            return new Angle(angle < 0 ? angle + 2 * PI : angle);
        }
    }
}
