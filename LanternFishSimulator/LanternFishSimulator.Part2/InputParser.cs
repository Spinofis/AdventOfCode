using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanternFishSimulator.Part2
{
    class InputParser
    {
        public static long[] GetPopulation(string path)
        {
            string input = File.ReadAllText(path);
            return input.Split(',')
                .Select(x => Convert.ToInt64(x))
                .ToArray();
        }
    }
}
