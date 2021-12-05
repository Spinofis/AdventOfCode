using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BingoSquid
{
    class InputParser
    {
        private const int LANE_SIZE = 5;

        private string file;
        private List<string> input;

        public InputParser(string _file)
        {
            file = _file;
        }

        public void ReadFile()
        {
            input = File.ReadAllLines(file).ToList();
        }

        public List<int> GetNumbers()
        {
            return input[0].Split(',').Select(x => Convert.ToInt32(x)).ToList();
        }

        public List<int[,]> GetArrays()
        {
            List<string> arrayInput = new List<string>();
            List<int[,]> arrays = new List<int[,]>();
            int[,] array = new int[LANE_SIZE, LANE_SIZE];
            for (int i = 2; i < input.Count; i++)
                if (!string.IsNullOrEmpty(input[i]))
                    arrayInput.Add(input[i]);

            for (int i = 0; i < arrayInput.Count; i++)
            {
                if (i % LANE_SIZE == 0)
                {
                    array = new int[LANE_SIZE, LANE_SIZE];
                    arrays.Add(array);
                    AssignArrayRow(arrayInput[i], array, i % LANE_SIZE);
                }
                else
                {
                    AssignArrayRow(arrayInput[i], array, i % LANE_SIZE);
                }
            }
            return arrays;
        }

        private void AssignArrayRow(string input, int[,] array, int rowIndex)
        {
            string[] row = input.Split(' ');
            int i = 0;
            foreach (var r in row)
            {
                if (!string.IsNullOrEmpty(r))
                    array[rowIndex, i++] = Convert.ToInt32(r);
            }
        }
    }
}
