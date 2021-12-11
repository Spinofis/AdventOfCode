using System;
using System.Collections.Generic;
using System.Text;

namespace OverlapingLinesD5
{
    public class MapAllLines : Map
    {
        public MapAllLines(List<Line> _lines)
        {
            lines = _lines;
        }

        protected override void AddLinesToMap(IEnumerable<Line> lines)
        {
            foreach (var line in lines)
            {
                IEnumerable<Point> points = line.GetPoints();
                AddPointToMap(points);
            }
        }
    }
}
