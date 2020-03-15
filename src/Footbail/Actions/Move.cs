namespace Footbail.Actions
{
    /// <summary>Represents a move action.</summary>
    public class Move
    {
        /// <summary>Creates a new instance of the <see cref="Move"/> class.</summary>
        public Move(Team team, int number, Velocity velocity)
        {
            Team = team;
            Number = number;
            Velocity = velocity;
        }

        /// <summary>Gets the team of the player to act.</summary>
        public Team Team { get; }

        /// <summary>Gets the number of the player to act.</summary>
        public int Number { get; }

        /// <summary>Gets the velocity to move with.</summary>
        public Velocity Velocity { get; set; }
    }
}
