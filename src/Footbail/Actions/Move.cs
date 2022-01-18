namespace Footbail.Actions
{
    /// <summary>Represents a move action.</summary>
    public sealed record Move(int Number, Velocity velocity) : PlayerAction;
}
