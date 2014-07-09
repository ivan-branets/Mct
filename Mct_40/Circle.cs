using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Mct_40
{
    class Circle
    {
        public Circle(int r, int centerX, int centerY)
        {
            if (r <= 0 || centerX <= 0 || centerY <= 0)
            {
                throw new ArgumentException("r, CenterX or CenterY must be > 0");
            }

            R = r;
            CenterX = centerX;
            CenterY = centerY;
        }
        private int R { get; set; }
        private int CenterX { get; set; }
        private int CenterY { get; set; }

        public PointCollection GetPoints()
        {
            var points = new PointCollection();

            for (var x = -R; x <= R; x++)
            {
                var y = GetY(x, R);
                AddPoint(points, x, y);
            }

            for (var x = R; x >= -R; x--)
            {
                var y = -GetY(x, R);
                AddPoint(points, x, y);
            }

            return points;
        }

        private void AddPoint(ICollection<Point> points, int x, int y)
        {
            var point = new Point(x + CenterX, y + CenterY);
            points.Add(point);            
        }

        private static int GetY(int x, int r)
        {
            int y = -1;
            int s;
            do
            {
                y++;
                s = x * x + y * y - r * r;
            }
            while (s < -r + 1 || s > r);
            return y;
            //return (int)Math.Sqrt(r * r - x * x);
        }
    }
}
