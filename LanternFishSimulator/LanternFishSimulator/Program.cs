using System;
using System.Collections.Generic;

namespace LanternFishSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Lanternfish> lanternfishes = InputParser.GetLanternfishes(@"C:\Nauka\AdventOfCode\LanternFishSimulator\input_part1.txt");
            LanternFishSimulator simulator = new LanternFishSimulator(lanternfishes);
            lanternfishes = simulator.GetLanternFishPopulation(days: 80);
            //simulator.PrintPopulation(80);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Population of lanternfish: {lanternfishes.Count}");
            Console.Read();
        }
    }
}
