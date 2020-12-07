using System.Collections.Generic;
using System.Linq;
using Tools;

namespace BinaryBoarding
{
    public class BoardingPassRepository : IBoardingPassRepository
    {
        private readonly IPuzzleInput _puzzleInput;
        private const string PuzzleInputUrl = "https://adventofcode.com/2020/day/5/input";

        private IEnumerable<string> _rawData;
        private IEnumerable<string> RawData => _rawData ??= _puzzleInput.GetPuzzleInputAsArray(PuzzleInputUrl);

        private IEnumerable<BoardingPass> _boardingPasses;

        private IEnumerable<BoardingPass> BoardingPasses =>
            _boardingPasses ??= RawData.Select(BoardingPass.CreateBoardingPass);

        public BoardingPassRepository(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }

        public int MaxSeatId => BoardingPasses.Max(bp => bp.SeatId);

        public int FindSeat()
        {
            var seatIdsPlusOne = BoardingPasses.Select(bp => bp.SeatId + 1);
            var seatIdsMinusOne = BoardingPasses.Select(bp => bp.SeatId - 1);

            var overlappingIds = seatIdsPlusOne.Intersect(seatIdsMinusOne);

            return overlappingIds.Except(BoardingPasses.Select(bp => bp.SeatId)).Max();
        }
    }
}