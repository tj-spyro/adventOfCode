using System.Collections.Generic;
using System.Linq;

namespace SpaceImageFormat
{
    public class ImageLayer
    {
        public ImageLayer(char[] data, int width, int height)
        {
            _data = data;
            Height = height;
            Width = width;
        }

        private readonly char[] _data;
        public readonly int Height;
        public readonly int Width;

        public char GetValueAtIndex(int x, int y)
        {
            return _data[x + y * Width];
        }

        public int GetNumberOfZeros()
        {
            return CountOccurances('0');
        }

        private int CountOccurances(char valueToCount)
        {
            return _data.Count(value => value == valueToCount);
        }

        public int ChecksumOnesAndTwos()
        {
            return CountOccurances('1') * CountOccurances('2');
        }

        public char[][] GetJaggedArray()
        {
            var rows = new List<char[]>();

            for (var y = 0; y < Height; y++)
            {
                var row = _data.Skip(y * Width).Take(Width).ToArray();
                rows.Add(row);
            }

            return rows.ToArray();
        }
    }
}