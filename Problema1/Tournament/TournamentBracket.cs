using System.Collections.Generic;
using System.Linq;

namespace Problema1.Tournament
{
    public class TournamentBracket
    {
        public IList<RpsPlayer> Players1 { get; private set; }
        public IList<RpsPlayer> Players2 { get; private set; }

        public TournamentBracket(IList<RpsPlayer> players1, IList<RpsPlayer> players2)
        {
            Players1 = players1;
            Players2 = players2;
        }
        
        public TournamentBracket()
        {
            Players1 = new List<RpsPlayer>();
            Players2 = new List<RpsPlayer>();
        }

        public bool AddPlayer(RpsPlayer player)
        {
            if (Players1.Count < 2)
            {
                Players1.Add(player);
                return true;
            }
            if (Players2.Count < 2)
            {
                Players2.Add(player);
                return true;
            }
            return false;
        }

    }
}
