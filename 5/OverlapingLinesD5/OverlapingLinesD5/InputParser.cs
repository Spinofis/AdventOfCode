using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverlapingLinesD5
{
    class InputParser
    {
        public List<Line> GetLines(List<string> input)
        {
            List<Line> lines = new List<Line>();
            foreach (var lineOfInput in input)
            {
                string[] splitedLineOfInput = lineOfInput.Split("->");
                int[] chordsP1 = splitedLineOfInput[0].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                int[] chordsP2 = splitedLineOfInput[1].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                lines.Add(new Line(new Point(chordsP1[0], chordsP1[1]), new Point(chordsP2[0], chordsP2[1])));
            }
            return lines;
        }
    }
}
