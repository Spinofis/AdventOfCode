using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LanternFishSimulator
{
    public class InputParser
    {
        public static List<Lanternfish> GetLanternfishes(string path)
        {
            return File.ReadAllText(path).Split(',')
                .Select(x => new Lanternfish(Convert.ToInt32(x)))
                .ToList();
        }
    }
}
