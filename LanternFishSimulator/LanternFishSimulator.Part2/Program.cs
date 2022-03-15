using System;
using System.Linq;

namespace LanternFishSimulator.Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] initPopulation = InputParser.GetPopulation(@"C:\Nauka\AdventOfCode\LanternFishSimulator\input_part2.txt");
            Simulator simulator = new Simulator(initPopulation);
            long[] fishes = simulator.GetNumberOfFishEachDay(256);
            Console.WriteLine($"Total population count {fishes.Sum()}");
            Console.Read();
        }
    }
}
