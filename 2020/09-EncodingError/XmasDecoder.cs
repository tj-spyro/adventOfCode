using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace EncodingError
{
    public class XmasDecoder : IXmasDecoder
    {
        private readonly IPuzzleInput _puzzleInput;
        private const string PuzzleInputUrl = "https://adventofcode.com/2020/day/9/input";

        private long[] _rawData;
        private long[] RawData => _rawData ??= _puzzleInput.GetPuzzleInputAsArray(PuzzleInputUrl).Select(long.Parse).ToArray();

        public XmasDecoder(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }

        public long FindFirstInvalidNumber(int preamble = 25)
        {
            for (var position = preamble; position < RawData.Length; position++)
            {
                if (!ValidNumber(position, preamble))
                {
                    return RawData[position];
                }
            }

            throw new ApplicationException("Not found!");
        }

        public long FindEncryptionWeakness(int preamble = 25)
        {
            var invalidNumber = FindFirstInvalidNumber(preamble);

            for (var i = 0; i < RawData.Length; i++)
            {
                var (found, min, max) = FindContiguousSet(invalidNumber, i);

                if (found)
                {
                    return min + max;
                }
            }

            throw new ApplicationException("Not found!");
        }

        public bool ValidNumber(int position, int preamble)
        {
            var target = RawData[position];

            var numbers = RawData[(position - preamble)..position];

            for (var i = 0; i < numbers.Length; i++)
            {
                for (var j = 1; j < numbers.Length; j++)
                {
                    if (numbers[i] != numbers[j] && numbers[i] + numbers[j] == target)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public (bool found, long min, long max) FindContiguousSet(long target, int startPosition)
        {
            var set = new List<long>();

            for (var i = startPosition; i < RawData.Length; i++)
            {
                set.Add(RawData[i]);

                if (set.Sum() == target)
                {
                    return (true, set.Min(), set.Max());
                }
            }

            return (false, set.Min(), set.Max());
        }
    }
}