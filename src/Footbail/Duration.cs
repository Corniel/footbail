using System;
using System.Globalization;

namespace Footbail
{
    /// <summary>Represents the duration of a match.</summary>
    public readonly struct Duration : IEquatable<Duration>, IComparable<Duration>
    {
        public static readonly int SecondsPerTick = 2;
        public static readonly int MinutesPerTick = 2 * 60;

        /// <summary>Gets a zero duration.</summary>
        public static readonly Duration Zero;

        /// <summary>Creates a new instance of the <see cref="Duration"/> struct.</summary>
        public Duration(int ticks) => Ticks = Guard.NotNegative(ticks, nameof(ticks));

        /// <summary>Gets the number of ticks (half seconds).</summary>
        public int Ticks { get; }

        private Duration Increment() => new Duration(Ticks + 1);
        private Duration Decrement() => new Duration(Ticks - 1);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is Duration other && Equals(other);
        
        /// <inheritdoc/>
        public bool Equals(Duration other) => Ticks == other.Ticks;

        /// <inheritdoc/>
        public override int GetHashCode() => Ticks;

        public int CompareTo(Duration other) => Ticks.CompareTo(other.Ticks);

        /// <summary>Represents the duration as <see cref="string"/>.</summary>
        public override string ToString()
        {
            var buffer = Ticks;
            var odd = (buffer & 1) == 1 ? 5 : 0;
            buffer >>= 1;
            var seconds = buffer % 60;
            var minutes = buffer / 60;

            return string.Format(CultureInfo.InvariantCulture, "{0}:{1:00}.{2}", minutes, seconds, odd);
        }

        /// <summary>Increases the duration with 1 tick.</summary>
        public static Duration operator ++(Duration duration) => duration.Increment();
        /// <summary>Decreases the duration with 1 tick.</summary>
        public static Duration operator --(Duration duration) => duration.Decrement();

        public static bool operator ==(Duration l, Duration r) => l.Equals(r);
        public static bool operator !=(Duration l, Duration r) => !(l == r);

        public static bool operator >(Duration l, Duration r) => l.CompareTo(r) > 0;
        public static bool operator <(Duration l, Duration r) => l.CompareTo(r) < 0;
        public static bool operator >=(Duration l, Duration r) => l.CompareTo(r) >= 0;
        public static bool operator <=(Duration l, Duration r) => l.CompareTo(r) <= 0;

        /// <summary>Gets the duration based on seconds.</summary>
        public static Duration FromSeconds(int seconds)=> new Duration(seconds * SecondsPerTick);

        /// <summary>Gets the duration based on minutes.</summary>
        public static Duration FromMinutes(int minutes) => new Duration(minutes * MinutesPerTick);
    }
}
