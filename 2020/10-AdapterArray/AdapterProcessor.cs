using System.Collections.Generic;
using System.Linq;
using Tools;

namespace AdapterArray
{
    public class AdapterProcessor : IAdapterProcessor
    {
        private readonly IPuzzleInput _puzzleInput;
        private const string PuzzleInputUrl = "https://adventofcode.com/2020/day/10/input";

        private int[] _rawData;
        private int[] RawData => _rawData ??= _puzzleInput.GetPuzzleInputAsArray(PuzzleInputUrl).Select(int.Parse).ToArray();

        public AdapterProcessor(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }

        public int Solve1()
        {
            var orderedInput = RawData.OrderBy(d => d).ToList();

            var deltaOnes = 0;
            var deltaThrees = 0;

            var previous = 0;

            foreach (var current in orderedInput)
            {
                if (current - previous == 1)
                {
                    deltaOnes++;
                }
                else
                {
                    deltaThrees++;
                }

                previous = current;
            }

            deltaThrees++;

            return deltaOnes * deltaThrees;
        }

        public long Solve2()
        {
            var orderedInput = RawData.ToList();
            orderedInput.Add(0);
            orderedInput.Add(orderedInput.Max()+3);
            orderedInput.Sort();

            var memo = new Dictionary<int, long> {[orderedInput.Count - 1] = 1};

            for (var k = orderedInput.Count - 2; k >= 0; k--)
            {
                long currentCount = 0;
                for (var connected = k + 1; connected < orderedInput.Count && orderedInput[connected] - orderedInput[k] <= 3; connected++)
                {
                    currentCount += memo[connected];
                }
                memo[k] = currentCount;
            }

            return memo[0];
        }
    }
}