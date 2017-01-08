using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Problema1;
using Problema1.Enumerators;
using Problema1.Exceptions;
using Problema1.Tournament;

namespace Tests
{
    [TestFixture]
    public class UnitTest1
    {
        private RpsGame _game;

        [SetUp]
        public void StartUp()
        {
            _game = new RpsGame();
        }

        private IList<RpsPlayer> GivenAListWithTwoPlayersWithInvalidMoves()
        {
            return new List<RpsPlayer>
            {
                new RpsPlayer("DarthVader", "D"),
                new RpsPlayer("Luke", "L")
            };
        }

        private IList<RpsPlayer> GivenAListWithMoreThanTwoPlayers()
        {
            return new List<RpsPlayer>
            {
                new RpsPlayer("Princess Leia", "R"),
                new RpsPlayer("Han Solo", "P"),
                new RpsPlayer("Chewbacca", "S")
            };
        }

        private IList<RpsPlayer> GivenAListWithTwoPlayers()
        {
            return new List<RpsPlayer>
            {
                new RpsPlayer("Luis", "R"),
                new RpsPlayer("Fernando", "S"),
            };
        }

        private Tournament GivenATournament()
        {
            var tournament = new Tournament(new List<TournamentBracket>()
            {
                new TournamentBracket(new List<RpsPlayer>() { new RpsPlayer("Armando", "P"), new RpsPlayer("Dave", "S") },
                                      new List<RpsPlayer>() { new RpsPlayer("Richard", "R"), new RpsPlayer("Michael", "S")}),
                new TournamentBracket(new List<RpsPlayer>() { new RpsPlayer("Allen", "S"), new RpsPlayer("Omer", "P") },
                                      new List<RpsPlayer>() { new RpsPlayer("David E.", "R"), new RpsPlayer("Richard X.", "P")})
            });
            return tournament;
        }


        [Test]
        public void GivenAListWithTwoPlayers_WhenValidateTheWinner_ShouldReturnTheWinner()
        {
            var twoPlayersList = GivenAListWithTwoPlayers();
            RpsPlayer winner = _game.GetWinner(twoPlayersList);
            winner.PlayerName.Should().Be("Luis");
            winner.Choice.Should().Be(RpsChoicesEnum.R);
        }

        [Test]
        public void GivenAListWithMoreThanTwoPlayers_WhenValidateTheWinner_ShouldRaiseAWrongNumberOfPlayersException()
        {
            var moreThanTwoPlayersList = GivenAListWithMoreThanTwoPlayers();
            var ex = Assert.Throws<WrongNumberOfPlayersException>(() => _game.GetWinner(moreThanTwoPlayersList));
        }

        [Test]
        public void GivenAListWithTwoPlayersWithInvalidMoves_ShouldRaiseANoSuchStrategyException()
        {
            var ex = Assert.Throws<NoSuchStrategyException>(() => GivenAListWithTwoPlayersWithInvalidMoves());
        }

        [Test]
        public void GivenATournament_WhenValidateTheWinner_ShouldReturnTheWinner()
        {
            var tournament = GivenATournament();
            var winner = _game.GetTournamentWinner(tournament);
            winner.PlayerName.Should().Be("Richard");
            winner.Choice.Should().Be(RpsChoicesEnum.R);
        }
    }
}
