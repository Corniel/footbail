using Footbail.Diagnostics;
using System.Collections;

namespace Footbail;

[DebuggerDisplay("{Id}, Players: {Count}")]
[DebuggerTypeProxy(typeof(CollectionDebugView))]
public sealed class Team : IReadOnlyCollection<Player>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly Player[] Players;

    public Team(TeamId id, params Player[] players)
    {
        Id = id;
        Players = players ?? Array.Empty<Player>();
    }

    public int Count => Players.Length;

    public TeamId Id { get; }
    public Player this[int number] => Players[number - 1];

    public Player Keeper => this[number: 1];

    public IEnumerable<Player> FieldPlayers => Players.Skip(1);

    public IEnumerator<Player> GetEnumerator() => Players.AsEnumerable().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
