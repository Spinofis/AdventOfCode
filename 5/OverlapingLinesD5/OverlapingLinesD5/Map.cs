using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverlapingLinesD5
{
    public abstract class Map
    {
        protected int[,] map;
        protected List<Line> lines;
        protected int maxY;
        protected int maxX;

        public int GetOverlappingPointsCount()
        {
            int totalPoints = 0;
            if (map == null)
                CreateMap();
            for (int i = 0; i < maxY; i++)
            {
                for (int j = 0; j < maxX; j++)
                    if (map[i, j] > 1) totalPoints++;
            }
            return totalPoints;
        }

        public void Print()
        {
            if (map == null)
                CreateMap();
            for (int i = 0; i < maxY; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < maxX; j++)
                {
                    Console.Write(map[i, j] + " ");
                }
            }
        }

        protected void CreateMap()
        {
            maxY = lines.Select(y => y.A.Y).Union(lines.Select(y => y.B.Y)).Max(y => y) + 1;
            maxX = lines.Max(x => x.B.X) + 1;
            map = new int[maxY, maxX];
            InitializeMapWithZeros();
            AddLinesToMap(lines);
        }

        protected virtual void AddLinesToMap(IEnumerable<Line> lines) 
        {
            foreach (var line in lines)
            {
                if (!line.IsStraightLine())
                    continue;
                IEnumerable<Point> points = line.GetPoints();
                AddPointToMap(points);
            }
        }

        protected void InitializeMapWithZeros()
        {
            for (int i = 0; i < maxY; i++)
                for (int j = 0; j < maxX; j++)
                    map[i, j] = 0;
        }

        protected void AddPointToMap(IEnumerable<Point> points)
        {
            foreach (var p in points)
                map[p.Y, p.X] += 1;
        }
    }
}
