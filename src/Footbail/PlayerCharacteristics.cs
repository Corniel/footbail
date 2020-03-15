using System;
using System.Globalization;

namespace Footbail
{
    /// <summary>Represents characteristics of a player.</summary>
    public class PlayerCharacteristics
    {
        /// <summary>Creates a new instance of the <see cref="PlayerCharacteristics"/> class.</summary>
        public PlayerCharacteristics() : this(30, 30, 30) { }

        /// <summary>Creates a new instance of the <see cref="PlayerCharacteristics"/> class.</summary>
        public PlayerCharacteristics(double speed, double power, double endurance)
        {
            Guard.WitinMargin(speed, nameof(speed));
            Guard.WitinMargin(power, nameof(power));
            Guard.WitinMargin(endurance, nameof(endurance));

            if (speed + power + endurance > 90)
            {
                throw new ArgumentException("Sum of the characteristics should be not more then 90.");
            }

            Speed = speed / 10d;
            Power = power / 2.5;
            Endurance = endurance;
        }

        /// <summary>Gets the (maximum) speed of a player.</summary>
        public double Speed { get; }

        /// <summary>Gets the (maximum) power of a player.</summary>
        public double Power { get; }

        /// <summary>Gets the endurance of a player.</summary>
        public double Endurance { get; }

        /// <summary>Gets the speed² of the player.</summary>
        public double Speed2 => Speed * Speed;

        /// <summary>Gets the power² of the player.</summary>
        public double Power2 => Power * Power;

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "Speed: {0}, Power: {1}, Endurance: {2}",
                Speed, 
                Power,
                Endurance);
        }
    }
}
