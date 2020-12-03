using System.Linq;
using Tools;

namespace TobogganTrajectory
{
    public class Map : IMap
    {
        private readonly IPuzzleInput _puzzleInput;
        private const char Tree = '#';
        private const string PuzzleInputUrl = "https://adventofcode.com/2020/day/3/input";

        private char[][] _data;
        private char[][] Data => _data ??= _puzzleInput.GetPuzzleInputAsArray(PuzzleInputUrl).Select(s => s.ToCharArray()).ToArray();

        private int MapWidth => Data[0].Length;
        private int MapHeight => Data.Length;

        private int _xCoordinate;
        private int _yCoordinate;

        public Map(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }

        public bool IsTree()
        {
            return Data[_yCoordinate][_xCoordinate] == Tree;
        }

        public bool Move(int right, int down)
        {
            _xCoordinate = (_xCoordinate + right) % MapWidth;
            _yCoordinate += down;

            return _yCoordinate < MapHeight - 1;
        }

        public void Reset()
        {
            _xCoordinate = 0;
            _yCoordinate = 0;
        }
    }
}