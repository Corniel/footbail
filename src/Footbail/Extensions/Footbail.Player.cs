namespace Footbail;

public static class FootbailExtensions
{
    public static int ClosedBy(this Player[] players, Position position, bool includeKeeper = false)
    {
        var player = includeKeeper ? 0 : 1;

        var shortest = (players[player].Position - position).Speed2;

        for (var index = player + 1; index < players.Length; index++)
        {
            var distance = (players[player].Position - position).Speed2;
            if (distance < shortest)
            {
                shortest = distance;
                player = index;
            }
        }
        return player;
    }
}
