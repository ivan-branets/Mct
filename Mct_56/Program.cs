using System;
using Extensions;

namespace Mct_56
{
    class Program
    {
        static void Main()
        {
            var cards = GetInitialPack();

            cards.Shuffle();
            cards.Log();

            Console.ReadKey();
        }

        static int[] GetInitialPack()
        {
            const int size = 36;
            var cards = new int[size];

            for (var i = 0; i < cards.Length; i++)
            {
                cards[i] = i;
            }

            return cards;
        }
    }
}
