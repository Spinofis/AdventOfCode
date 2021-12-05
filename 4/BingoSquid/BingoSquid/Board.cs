using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingoSquid
{
    class Board
    {
        private const int LANE_SIZE = 5;

        private readonly int[,] board;
        private readonly List<int> numbers;

        public Board(List<int> _numbers, int[,] _board) { numbers = _numbers; board = _board; }

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

        public List<Lane> GetMarkedLanes()
        {
            List<Lane> markedLanes = new List<Lane>();
            for (int i = 0; i < LANE_SIZE; i++)
            {
                int[] column = GetColumn(i).ToArray();
                int[] row = GetRow(i).ToArray();
                Lane columnResult = GetLaneIfMarked(column, LaneType.Column);
                Lane rowResult = GetLaneIfMarked(row, LaneType.Row);
                if (columnResult != null) markedLanes.Add(columnResult);
                if (rowResult != null) markedLanes.Add(rowResult);
            }
            return markedLanes;
        }

        private Lane GetLaneIfMarked(int[] lane, LaneType laneType)
        {
            int matchedNumbers = 0;
            foreach (int n in numbers)
            {
                if (lane.Contains(n))
                    matchedNumbers++;
                if (matchedNumbers == LANE_SIZE)
                    return new Lane()
                    {
                        LaneArray = lane,
                        Board = board,
                        LastMatchedNumberFromInput = n,
                        Type = laneType
                    };
            }
            return null;
        }

        private IEnumerable<int> GetColumn(int index)
        {
            for (int i = 0; i < LANE_SIZE; i++)
                yield return board[i, index];
        }

        private IEnumerable<int> GetRow(int index)
        {
            for (int i = 0; i < LANE_SIZE; i++)
                yield return board[index, i];
        }
    }
}
