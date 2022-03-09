namespace Footbail.Actions
{
    /// <summary>Represents a shoot action.</summary>
    public sealed record Shoot(TeamId Team, int Number, Velocity Velocity) : PlayerAction;
}
