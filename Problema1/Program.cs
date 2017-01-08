using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problema1.Tournament;

namespace Problema1
{
    class Program
    {
        static void Main(string[] args)
        {
            StartUp();
        }

        private static void StartUp()
        {
            Console.WriteLine("Please inform the type of the match: Normal or Tournament [N / T]");
            string key = Console.ReadKey().KeyChar.ToString().ToUpper();
            Console.WriteLine(string.Empty);
            if (key != "N" && key != "T")
            {
                Console.WriteLine("Invalid input.");
                StartUp();
                return;
            }
            if (key == "T")
                StartTournament();
            
            if (key == "N")
                StartNormalMatch();
        }

        private static void StartTournament()
        {
            Console.WriteLine("Inform the number of players (4 or 8):");
            short players;
            if (!short.TryParse(Console.ReadKey().KeyChar.ToString(), out players))
            {
                Console.WriteLine("Invalid input.");
                StartUp();
                return;
            }
            if (players != 4 && players != 8)
            {
                Console.WriteLine("Invalid input.");
                StartUp();
                return;
            }
            Console.WriteLine(string.Empty);
            RpsPlayer winner;
            try
            {
                List<TournamentBracket> tournamentBracketList = new List<TournamentBracket>() { new TournamentBracket() };
                for (var i = 0; i < players; i++)
                {
                    Console.WriteLine($"Inform the name of Player {i + 1}:");
                    var name = Console.ReadLine();
                    Console.WriteLine(string.Empty);
                    Console.WriteLine($"Inform the choice for Player {i + 1} [R/P/S]:");
                    var choice = Console.ReadKey().KeyChar.ToString();
                    Console.WriteLine(string.Empty);
                    var player = new RpsPlayer(name, choice);
                    if (!tournamentBracketList.Last().AddPlayer(player))
                    {
                        tournamentBracketList.Add(new TournamentBracket());
                        tournamentBracketList.Last().AddPlayer(player);
                    }
                }
                var tournament = new Tournament.Tournament(tournamentBracketList);
                var game = new RpsGame();
                winner = game.GetTournamentWinner(tournament);
            }
            catch (Exception e)
            {
                Console.WriteLine($"**** ERROR: {e.Message}");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("The winner is:");
            Console.WriteLine(winner.PlayerName);
            Console.WriteLine($"With his choice of {winner.Choice}");
            Console.ReadKey();
        }
        
        private static void StartNormalMatch()
        {
            Console.WriteLine("Inform the name of player 1:");
            var name1 = Console.ReadLine();
            Console.WriteLine(string.Empty);
            Console.WriteLine($"Inform the choice for Player 1 [R/P/S]:");
            var choice1 = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine(string.Empty);

            Console.WriteLine("Inform the name of player 2:");
            var name2 = Console.ReadLine();
            Console.WriteLine(string.Empty);
            Console.WriteLine($"Inform the choice for Player 2 [R/P/S]:");
            var choice2 = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine(string.Empty);
            RpsPlayer winner;
            try
            {
                var players = new List<RpsPlayer>() { new RpsPlayer(name1, choice1), new RpsPlayer(name2, choice2) };
                var game = new RpsGame();
                winner = game.GetWinner(players);
            }
            catch (Exception e)
            {
                Console.WriteLine($"**** ERROR: {e.Message}");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("The winner is:");
            Console.WriteLine(winner.PlayerName);
            Console.WriteLine($"With his choice of {winner.Choice}");
            Console.ReadKey();
        }
    }
}
