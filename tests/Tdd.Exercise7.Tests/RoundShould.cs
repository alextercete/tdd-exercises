
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace Tdd.Exercise7.Tests
{
    [TestFixture]
    public class RoundShould
    {
        private Round _round;
        private IPlayer _player1;
        private IPlayer _player2;

        [SetUp]
        public void SetUp()
        {
            _round = new Round();
            _player1 = Substitute.For<IPlayer>();
            _player2 = Substitute.For<IPlayer>();
        }

        [Test]
        public void Decide_scissors_beats_paper()
        {
            _player1.RevealHand().Returns(new Paper());
            _player2.RevealHand().Returns(new Scissors());

            var winner = _round.Play(_player1, _player2);
            winner.ShouldBe(Winner.Player2);
        }
        [Test]
        public void Decide_paper_beats_rock()
        {
            _player1.RevealHand().Returns(new Paper());
            _player2.RevealHand().Returns(new Rock());

            var winner = _round.Play(_player1, _player2);
            winner.ShouldBe(Winner.Player1);
        }

        [Test]
        public void Decide_rock_beats_scissors()
        {
            _player1.RevealHand().Returns(new Rock());
            _player2.RevealHand().Returns(new Scissors());

            var winner = _round.Play(_player1, _player2);
            winner.ShouldBe(Winner.Player1);
        }

        [Test]
        public void Decide_same_hands_are_a_draw()
        {
            _player1.RevealHand().Returns(new Rock());
            _player2.RevealHand().Returns(new Rock());

            var winner = _round.Play(_player1, _player2);
            winner.ShouldBe(Winner.None);
        }
    }

}