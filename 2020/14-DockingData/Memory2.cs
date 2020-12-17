using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Tools;
// ReSharper disable CheckNamespace

namespace DockingData
{
    public class Memory2 : IMemory
    {
        private readonly IPuzzleInput _puzzleInput;
        private readonly IBitMasker _bitMasker;
        private const string PuzzleInputUrl = "https://adventofcode.com/2020/day/14/input";

        private string[] _rawData;
        private string[] RawData => _rawData ??= _puzzleInput.GetPuzzleInputAsArray(PuzzleInputUrl);

        public Memory2(IPuzzleInput puzzleInput, IBitMasker bitMasker)
        {
            _puzzleInput = puzzleInput;
            _bitMasker = bitMasker;
        }

        private readonly IDictionary<int, long> _internalMemory = new Dictionary<int, long>();

        private static readonly Regex Regex = new Regex(@"^(mask = (?<mask>[01X]{36}))|(mem\[(?<address>\d+)\] = (?<value>\d+))$");

        public void Initialise()
        {
            var bitMask = string.Empty;

            foreach (var line in RawData)
            {
                var match = Regex.Match(line);
                if (match.Groups["mask"].Success)
                {
                    bitMask = match.Groups["mask"].Value;
                }
                else
                {
                    var value = long.Parse(match.Groups["value"].Value);
                    var address = int.Parse(match.Groups["address"].Value);

                    var addresses = _bitMasker.ApplyMultiple(bitMask, address).ToList();

                    addresses.ForEach(a => _internalMemory[(int)a] = value);
                }
            }
        }

        public long Sum() => _internalMemory.Values.Sum();
    }
}