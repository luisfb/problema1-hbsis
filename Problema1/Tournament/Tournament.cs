using System.Collections.Generic;

namespace Problema1.Tournament
{
    public class Tournament
    {
        public IList<TournamentBracket> Brackets { get; private set; }

        public Tournament(IList<TournamentBracket> brackets)
        {
            Brackets = brackets;
        }

    }
}
