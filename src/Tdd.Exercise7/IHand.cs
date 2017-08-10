using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tdd.Exercise7
{
    public interface IHand
    {
        bool Beats(IHand hand);

    }

    public class Rock : IHand
    {
        bool IHand.Beats(IHand hand)
        {
            return hand is Scissors;
        }
    }

    public class Paper : IHand
    {
        bool IHand.Beats(IHand hand)
        {
            return hand is Rock;
        }
    }

    public class Scissors : IHand
    {
        bool IHand.Beats(IHand hand)
        {
            return hand is Paper;
        }
    }
}
