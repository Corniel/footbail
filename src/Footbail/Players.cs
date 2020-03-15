using Footbail.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Footbail
{
    /// <summary>Represents all players of a football game.</summary>
    [DebuggerDisplay("Count = {Count}"), DebuggerTypeProxy(typeof(CollectionDebugView))]
    public sealed class Players : IEnumerable<Player>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Player[] lookup;

        /// <summary>Creates a new instance of the <see cref="Players"/> class.</summary>
        public Players(params Player[] players)
        {
            var size = players.Max(p => Index(p.Team, p.Number)) + 1;
            lookup = new Player[size];
           
            foreach(var player in players)
            {
                lookup[Index(player.Team, player.Number)] = player;
            }
        }
     
        /// <summary>Gets the specified player based on team and number.</summary>
        public Player this[Team team, int number] => lookup[Index(team, number)];

        /// <summary>The number of players.</summary>
        public int Count => Where(p => true).Count();

        /// <summary>Gets players that match a certain condition.</summary>
        public IEnumerable<Player> Where(Func<Player, bool> predicate)
        {
            return lookup.Where(p => p != null && predicate(p));
        }

        /// <inheritdoc/>
        public IEnumerator<Player> GetEnumerator()
        {
            return Where(p => true)
                .OrderBy(p => p.Team)
                .ThenBy(p => p.Number)
                .GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>Creates a unique index (hash) for a player.</summary>
        private int Index(Team team, int number) => (number << 1) | (int)team;
    }
}
