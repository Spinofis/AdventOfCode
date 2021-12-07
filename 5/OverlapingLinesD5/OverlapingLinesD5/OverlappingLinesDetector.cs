using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverlapingLinesD5
{
    public class OverlappingLinesDetector
    {
        private int[,] map;
        private List<Line> lines;
        private int maxY;
        private int maxX;

        public OverlappingLinesDetector(List<Line> _lines)
        {
            lines = _lines;
        }

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

        private void CreateMap()
        {
            maxY = lines.Select(y => y.A.Y).Union(lines.Select(y => y.B.Y)).Max(y => y);
            maxX = lines.Max(x => x.B.X);
            map = new int[maxY + 1, maxX + 1];
            InitializeMapWithZeros();
            foreach (var line in lines)
            {
                IEnumerable<Point> points = line.GetPoints();
                AddPointsToMap(points);
            }
        }

        private void InitializeMapWithZeros()
        {
            for (int i = 0; i < maxY; i++)
                for (int j = 0; j < maxX; j++)
                    map[i, j] = 0;
        }

        private void AddPointsToMap(IEnumerable<Point> points)
        {
            foreach (var p in points)
                map[p.Y, p.X] += 1;
        }
    }
}
