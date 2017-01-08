using System;
using System.Collections.Generic;
using System.Linq;
using Problema1.Enumerators;
using Problema1.Exceptions;
using Problema1.Tournament;

namespace Problema1
{
    public class RpsGame
    {
        public RpsPlayer GetWinner(IList<RpsPlayer> players)
        {
            if(players.Count != 2)
                throw new WrongNumberOfPlayersException($"Wrong number of players: {players.Count}");

            var player1 = players[0];
            var player2 = players[1];

            if(player1.Choice == player2.Choice)
                return player1;

            RpsPlayer winner;

            switch (player1.Choice)
            {
                case RpsChoicesEnum.R:
                    winner = player2.Choice == RpsChoicesEnum.S ? player1 : player2;
                    break;
                case RpsChoicesEnum.P:
                    winner = player2.Choice == RpsChoicesEnum.R ? player1 : player2;
                    break;
                case RpsChoicesEnum.S:
                    winner = player2.Choice == RpsChoicesEnum.P ? player1 : player2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return winner;
        }

        /*
        No arquivo PDF tem um requisito que diz o seguinte:
            You can assume that the initial tournament is well-formed (that is, there are 2^n
            players, and each one participates in exactly one match per round)
        Portanto, eu não considerei no código que o torneio pudesse ter 3 ou 5 chaves de torneio (TournamentBracket), por exemplo.
        Há um teste unitário validando o resultado proposto pelo arquivo pdf.

        O jogo pode ser executado e testado via console ou pelo projeto Tests.
        */

        public RpsPlayer GetTournamentWinner(Tournament.Tournament tournament)
        {
            RpsPlayer winner = null;
            List<RpsPlayer> phaseWinners = new List<RpsPlayer>();
            foreach (var bracket in tournament.Brackets)
            {
                var winner1 = GetWinner(bracket.Players1);
                if (!bracket.Players2.Any())
                {
                    //last tournament match
                    winner = winner1;
                    break;
                }
                var winner2 = GetWinner(bracket.Players2);
                phaseWinners.Add(winner1);
                phaseWinners.Add(winner2);
            }
            if (winner != null) return winner;
            var nextBrackets = new List<TournamentBracket>() { new TournamentBracket() };
            foreach (var phaseWinner in phaseWinners)
            {
                if (nextBrackets.Last().AddPlayer(phaseWinner)) continue;
                nextBrackets.Add(new TournamentBracket());
                nextBrackets.Last().AddPlayer(phaseWinner);
            }
            Tournament.Tournament nextTournamentPhase = new Tournament.Tournament(nextBrackets);
            winner = GetTournamentWinner(nextTournamentPhase);
            return winner;
        }
    }
}
