using System;
using Extensions;

namespace Mct_56
{
    class Program
    {
        static void Main()
        {
            var cards = GetInitialPack();

            Shuffle(cards);
            cards.Log();

            Console.ReadKey();
        }

        static void Shuffle(int[] cards)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            var lastIndex = cards.Length - 1;

            for (var i = 0; i < cards.Length / 2; i++)
            {
                var j = rand.Next(i + 1, lastIndex);
                Swap(cards, i, j);

                j = rand.Next(0, lastIndex - i);
                Swap(cards, lastIndex - i, j);
            }
        }

        static void Swap(int[] array, int i, int j)
        {
            //no exta storage
            array[i] += array[j];
            array[j] = array[i] - array[j];
            array[i] -= array[j];
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
