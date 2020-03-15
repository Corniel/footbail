using System.Globalization;

namespace Footbail
{
    /// <summary>Represents the ball in a football game.</summary>
    public class Ball
    {
        /// <summary>Creates a new instance of the <see cref="Ball"/> class.</summary>
        public Ball(Position position, Velocity velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        /// <summary>Gets the current position of the ball.</summary>
        public Position Position { get; private set; }

        /// <summary>Gets the current velocity of the ball.</summary>
        public Velocity Velocity { get; private set; }

        /// <summary>Moves the ball with the specified velocity.</summary>
        public void Move(Velocity velocity)
        {
            Velocity = velocity;
            Position += Velocity;
        }

        /// <summary>Represents the ball as a <see cref="string"/>.</summary>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture, 
                "Position: {0}, Velocity: {1}",
                Position,
                Velocity);
        }
    }
}
