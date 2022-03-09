namespace Footbail.Actions;

public interface PlayerAction
{
    TeamId Team { get; }
    int Number { get; }
}
