using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingoSquid
{
    public class BingoGame2
    {
        private const int BOARDS_NUMBER = 3;

        private readonly List<int> numbers;
        private readonly List<int[,]> boardsArrays;
        private readonly List<Board2> boards = new List<Board2>();


        public BingoGame2(List<int> _numbers, List<int[,]> _boardsArrays) { numbers = _numbers; boardsArrays = _boardsArrays; }

        public Lane Solve()
        {
            List<Lane> lanes = new List<Lane>();
            Lane winLane = null;
            for (int i = 0; i < BOARDS_NUMBER; i++)
                boards.Add(new Board2(numbers, boardsArrays[i]));
            foreach (var board in boards)
                lanes.AddRange(board.GetLanes());
            foreach (var n in numbers)
            {
                MarkNumberInLanes(n, lanes);
                winLane = lanes.Where(x => x.IsWin()).FirstOrDefault();
                if (winLane != null)
                    break;
            }
            winLane.Score = winLane.GetScore(numbers);
            return winLane;
        }

        private void MarkNumberInLanes(int n, List<Lane> lanes)
        {
            foreach (var l in lanes)
            {
                l.Mark(n);
            }
        }
    }
}
