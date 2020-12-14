using System.Collections.Generic;
using System.Linq;
using Tools;
// ReSharper disable CheckNamespace

namespace ShuttleSearch
{
    public class TimeTable : ITimeTable
    {
        private readonly IPuzzleInput _puzzleInput;
        private const string PuzzleInputUrl = "https://adventofcode.com/2020/day/13/input";

        private string[] _rawData;
        private string[] RawData => _rawData ??= _puzzleInput.GetPuzzleInputAsArray(PuzzleInputUrl);

        public TimeTable(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }

        private int? _timestamp;
        private int Timestamp => _timestamp ??= int.Parse(RawData[0]);

        private IEnumerable<Bus> _buses;

        private IEnumerable<Bus> Buses =>
            _buses ??= RawData[1].Split(',').Where(d => !d.Equals("x")).Select(b => new Bus(b));

        public int NextDeparture()
        {
            return Buses.OrderBy(b => b.NextDeparture(Timestamp)).First().NextDeparture(Timestamp);
        }

        public int WaitTime()
        {
            return Buses.OrderBy(b => b.NextDeparture(Timestamp)).First().WaitTime(Timestamp);
        }

        public int Solve1()
        {
            return Buses.OrderBy(b => b.NextDeparture(Timestamp)).First().Id * WaitTime();
        }

        public int Solve2()
        {
            return -1;
        }
    }
}