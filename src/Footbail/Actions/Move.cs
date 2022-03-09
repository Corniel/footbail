namespace Footbail.Actions
{
    /// <summary>Represents a move action.</summary>
    public record Move(TeamId Team, int Number, Velocity Velocity = default) : PlayerAction;
}
