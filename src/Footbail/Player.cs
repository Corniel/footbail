using System.Globalization;

namespace Footbail
{
    /// <summary>Represents a player in a football match.</summary>
    public class Player
    {
        /// <summary>Creates a new instance of the <see cref="Player"/> class.</summary>
        public Player(
            Team team,
            int number,
            PlayerCharacteristics characteristics,
            Position position, 
            Velocity velocity,
            double fitness)
        {
            Team = team;
            Number = number;
            Characteristics = characteristics ?? new PlayerCharacteristics();
            Position = position;
            Velocity = velocity;
            Fitness = fitness;
        }

        /// <summary>Gets the team of the player.</summary>
        public Team Team { get; }

        /// <summary>Gets the number of the player.</summary>
        public int Number { get; }

        /// <summary>Gets the characteristics of the player.</summary>
        public PlayerCharacteristics Characteristics { get; }

        /// <summary>Gets the current position of the player.</summary>
        public Position Position { get; private set; }

        /// <summary>Gets the current position of the velocity.</summary>
        public Velocity Velocity { get; private set; }

        /// <summary>Gets the current fitness of the velocity.</summary>
        public double Fitness { get; private set; }

        /// <summary>Moves the player with the specified velocity and updates the fitness.</summary>
        public void Move(Velocity velocity, double fitness)
        {
            Position += velocity;
            Velocity = velocity;
            Fitness = fitness;
        }

        /// <summary>Represents the player as a <see cref="string"/>.</summary>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "ID: {0}{1:00},  Position: {2}, Velocity: {3}",
                Team.ToString()[0],
                Number,
                Position,
                Velocity);
        }
    }
}
