using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Extensions;

namespace Mct_49
{
    class Program
    {
        static void Main()
        {
            var characters = new Characters(new byte[] { 2, 128, 8, 7, 130, 67, 8, 130, 3, 8 });
            Output(characters);

            characters.Backspace(5);
            Output(characters, 5);

            characters.Backspace(4);
            Output(characters, 4);

            characters.Backspace(1);
            Output(characters, 1);

            characters.Backspace(1);
            Output(characters, 1);

            characters.Backspace(3);
            Output(characters, 3);

            characters.Backspace(2);
            Output(characters, 2);

            characters.Backspace(1);
            Output(characters, 1);

            Console.WriteLine("----------------");

            characters = new Characters(new byte[]{ 128, 2 });
            Output(characters);

            //characters.Backspace(0);
            //characters.Backspace(2);
            characters.Backspace(1);
            Output(characters, 1);

            //new Characters(null);

            Console.ReadKey();
        }

        private static void Output(Characters characters, int? index = null)
        {
            if (index.HasValue)
            {
                Console.WriteLine("Backspace index {0}", index);                
            }

            foreach (var ch in characters)
            {
                ch.Log();
            }

            Console.WriteLine();
        }
    }

    class Characters : IEnumerable<byte[]>
    {
        public Characters(byte[] array)
        {
            if (array == null) throw new ArgumentNullException();
            Array = array;
        }

        private byte[] Array { get; set; }

        public void Backspace(int index)
        {
            if (index < 1 || index > this.Count()) throw new ArgumentOutOfRangeException();

            var pos = GetStartCharacterPosition(index);
            var isKanjiFirstByte = pos > 1 && IsKanjiFirstByte(Array[pos - 2]);

            var toBeRemovedCharactedPos = isKanjiFirstByte ? pos - 2 : pos - 1;
            var tmp = new byte[isKanjiFirstByte ? Array.Length - 2 : Array.Length - 1];

            var j = 0;

            for (var i = 0; i < toBeRemovedCharactedPos; i++)
            {
                tmp[j++] = Array[i];
            }

            for (var i = pos; i < Array.Length; i++)
            {
                tmp[j++] = Array[i];
            }

            Array = tmp;
        }

        private bool IsKanjiFirstByte(byte @byte)
        {
            return (@byte & 128) > 0;
        }

        private int GetStartCharacterPosition(int index)
        {
            var pos = 0;
            var enumerator = GetEnumerator();

            for (var i = 0; i < index; i++)
            {
                enumerator.MoveNext();
                pos += enumerator.Current.Length > 1 ? 2 : 1;
            }

            return pos;
        }

        public IEnumerator<byte[]> GetEnumerator()
        {
            for (var i = 0; i < Array.Length; i++)
            {
                if (IsKanjiFirstByte(Array[i]))
                {
                    yield return new[] { Array[i], Array[++i] };
                }
                else
                {
                    yield return new []{ Array[i] };
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
