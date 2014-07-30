using System;
using System.Collections.Generic;
using Extensions;

namespace Mct_54
{
    class Program
    {
        static void Main()
        {
            new[,]
            {
                {  1,  2,  3,  4 },
                { 12, 13, 14,  5 },
                { 11, 16, 15,  6 },
                { 10,  9,  8,  7 }
            }
            .Spiral().Log();

            new[,]
            {
                {  1,  2,  3,  4 },
                { 10, 11, 12,  5 },
                {  9,  8,  7,  6 }
            }
            .Spiral().Log();

            new[,]
            {
                {  1,  2,  3 },
                { 10, 11,  4 },
                {  9, 12,  5 },
                {  8,  7,  6 }
            }
            .Spiral().Log();

            new[,]
            {
                { 1, 2 },
                { 4, 3 }
            }
            .Spiral().Log();

            new[,]
            {
                { 1, 2 }
            }
            .Spiral().Log();

            new[,]
            {
                { 1 }
            }
            .Spiral().Log();

            new int[0, 0]
            .Spiral().Log();

            //int[,] matrix = null;
            //matrix.Spiral().Log();

            Console.ReadKey();
        }
    }

    static class MatrixExtension
    {
        enum Direction
        {
            Left,
            Right,
            Top,
            Bottom
        }

        public static IEnumerable<int> Spiral(this int[,] matrix)
        {
            if (matrix == null) throw new ArgumentNullException();

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            var left = 0;
            var right = cols - 1;
            var top = 0;
            var bottom = rows - 1;

            var direction = Direction.Right;
            var i = 0;
            var j = 0;

            for (var z = 0; z < matrix.Length; z++)
            {
                yield return matrix[i, j];

                switch (direction)
                {
                    case Direction.Right:
                        if (j == right) { direction = Direction.Bottom; i++; top++; }
                        else j++;
                        break;
                    case Direction.Bottom:
                        if (i == bottom) { direction = Direction.Left; j--; right--; }
                        else i++;
                        break;
                    case Direction.Left:
                        if (j == left) { direction = Direction.Top; i--; bottom--; }
                        else j--;
                        break;
                    case Direction.Top:
                        if (i == top) { direction = Direction.Right; j++; left++; }
                        else i--;
                        break;
                }
            }
        }
    }
}
