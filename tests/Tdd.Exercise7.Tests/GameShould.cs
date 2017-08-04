using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace Tdd.Exercise7.Tests
{
    [TestFixture]
    public class GameShould
    {
        private Round _round;
        private Game _game;
        private IPlayer _player1;
        private IPlayer _player2;

        [SetUp]
        public void SetUp()
        {
            _round = new Round();
            _game = new Game(_round);

            _player1 = Substitute.For<IPlayer>();
            _player2 = Substitute.For<IPlayer>();
        }

        [Test]
        public void Decide_the_winner_based_on_round_results()
        {
            _player1.RevealHand().Returns(new Paper());
            _player2.RevealHand().Returns(new Scissors());

            GameResult result = _game.Play(_player1, _player2);
            result.WinningPlayer.ShouldBe(_player2);
        }

        [Test]
        public void Decide_the_winner_after_at_least_three_rounds()
        {
            _player1.RevealHand().Returns(new Paper(), new Paper(), new Paper());
            _player2.RevealHand().Returns(new Scissors(), new Rock(), new Rock());


            GameResult result = _game.Play(_player1, _player2);
            result.RoundCount.ShouldBe(3);
            result.WinningPlayer.ShouldBe(_player1);
        }

        [Test]
        public void Continue_until_there_is_a_clear_winner()
        {
            _player1.RevealHand().Returns(new Paper(), new Paper(), new Paper(), new Paper());
            _player2.RevealHand().Returns(new Rock(), new Scissors(), new Paper(), new Rock());

            GameResult result = _game.Play(_player1, _player2);
            result.RoundCount.ShouldBe(4);
            result.WinningPlayer.ShouldBe(_player1);
        }

        [Test]
        public void Continue_until_the_first_winner_after_three_draws()
        {
            _player1.RevealHand().Returns(new Paper(), new Paper(), new Paper(), new Paper());
            _player2.RevealHand().Returns(new Paper(), new Paper(), new Paper(), new Rock());

            GameResult result = _game.Play(_player1, _player2);
            result.RoundCount.ShouldBe(4);
            result.WinningPlayer.ShouldBe(_player1);
        }
    }
}