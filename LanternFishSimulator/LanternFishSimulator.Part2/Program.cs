using System;

namespace LanternFishSimulator.Part2
{
    class Program
    {
        static async void Main(string[] args)
        {
            await InputParser.GetPopulation(@"C:\Nauka\AdventOfCode\LanternFishSimulator\input_part1.txt");
            Console.WriteLine("Hello World!");
        }
    }
}
