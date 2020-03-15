namespace Footbail.Actions
{
    /// <summary>Represents a shoot action.</summary>
    public class Shoot
    {
        /// <summary>Creates a new instance of the <see cref="Shoot"/> class.</summary>
        public Shoot(Team team, int number, Velocity velocity)
        {
            Team = team;
            Number = number;
            Velocity = velocity;
        }

        /// <summary>Gets the team of the player to act.</summary>
        public Team Team { get; }

        /// <summary>Gets the number of the player to act.</summary>
        public int Number { get; }

        /// <summary>Gets the velocity to shoot with.</summary>
        public Velocity Velocity { get; set; }
    }
}
