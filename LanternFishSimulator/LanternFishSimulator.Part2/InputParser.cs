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
        public static async Task<List<int>> GetPopulation(string path)
        {
            string input = await File.ReadAllTextAsync(path);
            return input.Split(',')
                .Select(x => Convert.ToInt32(x))
                .ToList();
        }
    }
}
