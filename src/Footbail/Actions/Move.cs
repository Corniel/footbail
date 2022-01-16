namespace Footbail.Actions
{
    /// <summary>Represents a move action.</summary>
    public sealed record Move(TeamId Team, int Number, Velocity velocity);
}
