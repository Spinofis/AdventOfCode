using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingoSquid
{
    public class Lane
    {
        private const int LANE_SIZE = 5;

        public int[,] Board { get; set; }
        public int Score { get; set; }
        public int[] LaneArray
        {
            get
            {
                return laneArray;
            }
            set
            {
                laneArray = value;
                laneArrayToMark = new int[LANE_SIZE];
                for (int i = 0; i < LANE_SIZE; i++)
                    laneArrayToMark[i] = laneArray[i];
            }
        }
        public int LastMatchedNumberFromInput { get; set; }
        public LaneType Type { get; set; }

        private int matchCount = 0;
        private int[] laneArrayToMark;
        private int[] laneArray;

        public bool IsWin() => matchCount == LANE_SIZE;

        public void Mark(int n)
        {
            for (int i = 0; i < laneArrayToMark.Length; i++)
            {
                if (laneArrayToMark[i] == n)
                {
                    matchCount++;
                    LastMatchedNumberFromInput = matchCount == LANE_SIZE ? n : 0;
                    laneArrayToMark[i] = -laneArrayToMark[i];
                }
            }
        }

        public int GetScore(List<int> numbers)
        {
            int total = 0;
            List<int> numbersBeforeLastMatch = numbers.GetRange(0, numbers.FindIndex(0, numbers.Count, x => x == LastMatchedNumberFromInput) + 1);
            for (int i = 0; i < LANE_SIZE; i++)
                for (int j = 0; j < LANE_SIZE; j++)
                    if (!numbersBeforeLastMatch.Contains(Board[i, j]))
                        total += Board[i, j];
            return total * LastMatchedNumberFromInput;
        }
    }
}
