using System;
using System.Collections.Generic;
using System.Text;

namespace BingoSquid
{
    public class BingoGame
    {
        private const int BOARDS_NUMBER = 3;

        private readonly List<int> numbers;
        private readonly List<int[,]> boardsArrays;
        private readonly List<Board> boards = new List<Board>();


        public BingoGame(List<int> _numbers, List<int[,]> _boardsArrays) { numbers = _numbers; boardsArrays = _boardsArrays; }


        public Lane Solve()
        {
            List<Lane> laneResults = new List<Lane>();
            for (int i = 0; i < BOARDS_NUMBER; i++)
                boards.Add(new Board(numbers, boardsArrays[i]));
            foreach (var board in boards)
                laneResults.AddRange(board.GetMarkedLanes());
            Lane winLane = GetWinningLane(laneResults);
            winLane.Score = winLane.GetScore(numbers);
            return winLane;
        }

        private Lane GetWinningLane(List<Lane> laneResults)
        {
            int firstMatchedNumberIndex = numbers.Count - 1;
            Lane winResult = null;
            foreach (var result in laneResults)
            {
                int index = numbers.FindIndex(0, numbers.Count, x => x == result.LastMatchedNumberFromInput);
                if (index < firstMatchedNumberIndex)
                {
                    firstMatchedNumberIndex = index;
                    winResult = result;
                }
            }
            return winResult;
        }
    }
}
