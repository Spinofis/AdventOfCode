using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverlapingLinesD5
{
    public class OverlappingLinesDetector
    {
        private int[,] map;

        public OverlappingLinesDetector(List<Line> lines)
        {
            int maxY = lines.Select(y => y.A.Y).Union(lines.Select(y => y.B.Y)).Max(y => y);
            int maxX = lines.Max(x => x.B.X);
            map = new int[maxY + 1, maxX + 1];
        }
    }
}
