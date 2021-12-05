using System;
using System.Collections.Generic;
using System.Text;

namespace BingoSquid
{
    public class Board2
    {
        private const int LANE_SIZE = 5;

        private readonly int[,] board;
        private readonly List<int> numbers;

        public Board2(List<int> _numbers, int[,] _board) { numbers = _numbers; board = _board; }

        public List<Lane> GetLanes()
        {
            List<Lane> lanes = new List<Lane>();
            int[] column;
            int[] row;
            for (int i = 0; i < LANE_SIZE; i++)
            {
                column = new int[5];
                row = new int[5];
                for (int j = 0; j < LANE_SIZE; j++)
                {
                    row[j] = board[i, j];
                    column[j] = board[j, i];
                }
                lanes.Add(new Lane() { LaneArray = row, Board = board });
                lanes.Add(new Lane() { LaneArray = column, Board = board });
            }
            return lanes;
        }
    }
}
