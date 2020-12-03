using System.Collections.Generic;
using System.Linq;

namespace TobogganTrajectory
{
    public class Map
    {
        private const char Tree = '#';

        private readonly char[][] _data;

        private readonly int _mapWidth;
        private readonly int _mapHeight;

        private int _xCoordinate;
        private int _yCoordinate;

        public Map(IEnumerable<string> rawData)
        {
            _data = rawData.Select(s => s.ToCharArray()).ToArray();

            _mapWidth = _data[0].Length;
            _mapHeight = _data.Length;
        }

        public bool IsTree()
        {
            return _data[_yCoordinate][_xCoordinate] == Tree;
        }

        public bool Move(int right, int down)
        {
            _xCoordinate = (_xCoordinate + right) % _mapWidth;
            _yCoordinate += down;

            return _yCoordinate < _mapHeight - 1;
        }
    }
}