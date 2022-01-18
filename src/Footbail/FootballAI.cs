using Footbail.Actions;

namespace Footbail;

public interface FootballAI
{
    IEnumerable<PlayerAction> Actions(Match match);
}
