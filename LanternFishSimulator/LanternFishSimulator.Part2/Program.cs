using System;

namespace LanternFishSimulator.Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initPopulation =  InputParser.GetPopulation(@"C:\Nauka\AdventOfCode\LanternFishSimulator\input_part1.txt");
            Simulator simulator = new Simulator(initPopulation);
            int[] population = simulator.GetPopulation(18, true);
            Console.Read();
        }
    }
}
