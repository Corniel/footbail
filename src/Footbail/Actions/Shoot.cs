namespace Footbail.Actions
{
    /// <summary>Represents a shoot action.</summary>
    public sealed record Shoot(int Number, Velocity Velocity) : PlayerAction;
}
