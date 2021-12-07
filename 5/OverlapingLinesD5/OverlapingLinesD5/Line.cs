using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverlapingLinesD5
{
    public class Line
    {
        public Point A { get; set; }
        public Point B { get; set; }

        public Line(Point p1, Point p2)
        {
            if (p1.X < p2.X)
            {
                A = p1; B = p2;
            }
            else
            {
                A = p2; B = p1;
            }
        }

        public void Print()
        {
            Console.Write($"{A.X},{A.Y} -> {B.X},{B.Y}");
            //foreach (var p in points)
            //    Console.Write($" {p.X},{p.Y} ");
            Console.Write("\n");
        }

        public IEnumerable<Point> GetPoints()
        {
            foreach (var x in Enumerable.Range(A.X, B.X - A.X + 1))
                yield return new Point(x, GetY(x));
        }

        public int GetY(int x)
        {
            int a = (A.Y - B.Y) / (A.X - B.X);
            int b = A.Y - a * A.X;
            return a * x + b;
        }
    }
}
