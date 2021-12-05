using System;
using System.Collections.Generic;

namespace BingoSquid
{
    class Program
    {
        const int LANE_SIZE = 5;

        static void Main(string[] args)
        {
            //List<int> numbers = new List<int> { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };
            ////List<int> numbers = new List<int> { 7, 4, 0, 24, 7, 5, 19, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };

            //int[,] board1 = new int[5, 5]
            //{
            //    { 22, 13, 17 ,11 , 0},
            //    {  8 , 2, 23 , 4 ,24},
            //    { 21 , 9, 14 ,16 , 7},
            //    { 6 ,10  ,3 ,18,  5},
            //    { 1, 12, 20 ,15, 19}
            //};
            //int[,] board2 = new int[5, 5]
            //{
            //    { 3, 15,  0,  2, 22 },
            //    { 9, 18, 13, 17,  5},
            //    { 19,  8,  7, 25, 23},
            //    { 20, 11, 10, 24,  4},
            //    { 14, 21, 16, 12,  6}
            //};
            //int[,] board3 = new int[5, 5]
            //{
            //    { 14, 21, 17, 24,  4},
            //    { 10, 16, 15,  9, 19},
            //    { 18,  8, 23, 26, 20},
            //    { 22, 11, 13,  6,  5},
            //    { 2,  0, 12,  3,  7}
            //};
            //List<int[,]> boardsArrays = new List<int[,]> { board1, board2, board3 };

            InputParser parser = new InputParser(@"C:\Nauka\AdventOfCode\4\input.txt");
            parser.ReadFile();
            List<int> numbers = parser.GetNumbers(); ;
            List<int[,]> boardsArrays = parser.GetArrays();

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.Write("\n");
            Console.Write("\n");
            foreach (var array in boardsArrays)
            {
                Console.Write("\n");
                Console.Write("\n");
                for (int i = 0; i < LANE_SIZE; i++)
                {
                    for (int j = 0; j < LANE_SIZE; j++)
                        Console.Write(array[i, j] + " ");
                    Console.Write("\n");
                    Console.Write("\n");
                }
            }

            BingoGame2 game = new BingoGame2(numbers, boardsArrays);
            Lane result = game.Solve();
            Console.WriteLine("BOARD: \n");
            for (int i = 0; i < LANE_SIZE; i++)
            {
                for (int j = 0; j < LANE_SIZE; j++)
                    Console.Write(result.Board[i, j] + " ");
                Console.Write("\n");
            }
            Console.Write("\n");
            Console.WriteLine("LANE: \n");
            for (int i = 0; i < LANE_SIZE; i++)
                Console.Write(result.LaneArray[i] + " ");
            Console.Write("\n");
            Console.Write("\n");
            Console.WriteLine("SCORE: \n");
            Console.WriteLine(result.Score);
            Console.ReadLine();
        }
    }
}
