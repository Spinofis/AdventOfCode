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

        public List<Point> GetPoints()
        {
            List<Point> points = new List<Point>();
            if (A.X == B.X)
            {
                foreach (int y in Enumerable.Range(Math.Min(A.Y, B.Y), Math.Abs(A.Y - B.Y) + 1))
                    points.Add(new Point(A.X, y));
                return points;
            }
            foreach (var x in Enumerable.Range(A.X, B.X - A.X + 1))
                points.Add(new Point(x, GetY(x)));
            return points;
        }

        public int GetY(int x)
        {
            if (A.X == B.X)
                throw new ArgumentException("A.X and B.X cant be equal!");
            int a = (A.Y - B.Y) / (A.X - B.X);
            int b = A.Y - a * A.X;
            return a * x + b;
        }

        public bool IsStraightLine() => A.X == B.X || A.Y == B.Y;
    }
}
