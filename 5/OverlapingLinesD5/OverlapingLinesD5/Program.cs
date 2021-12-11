﻿using System;

namespace OverlapingLinesD5
{
    class Program
    {
        static void Main(string[] args)
        {
            InputReader reader = new InputReader(@"C:\Nauka\AdventOfCode\5\points.txt");
            InputParser parser = new InputParser();
            var lines = parser.GetLines(reader.Read());
            foreach (var line in lines)
            {
                line.Print();
            }
            Console.WriteLine($"Lines count: {lines.Count}");
            Map map = new MapAllLines(lines);
            //map.Print();
            int totalPoints = map.GetOverlappingPointsCount();
            Console.WriteLine($"Overlapping points count: {totalPoints}");
            Console.ReadKey();
        }
    }
}
