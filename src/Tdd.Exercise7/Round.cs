namespace Tdd.Exercise7
{
    public class Round
    {
        public Winner Play(IPlayer player1, IPlayer player2)
        {

            var hand1 = player1.RevealHand();
            var hand2 = player2.RevealHand();

            if (hand1.Beats(hand2))
            {
                return Winner.Player1;
            }
            else if (hand2.Beats(hand1))
            {
                return Winner.Player2;
            }
            else
            {
                return Winner.None;
            }

        }
    }
}