using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace ExpenseReport
{
    public class ReportAnalyser : IReportAnalyser
    {
        private readonly IPuzzleInput _puzzleInput;
        private const string PuzzleInputUrl = "https://adventofcode.com/2020/day/1/input";

        private int[] _report;
        private IEnumerable<int> Report => _report ??= _puzzleInput.GetPuzzleInputAsArray(PuzzleInputUrl).Select(int.Parse).ToArray();

        public ReportAnalyser(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }

        public (int, int) FindTwoValuesTotalling(int sumOfValues)
        {
            foreach (var value1 in Report)
            {
                foreach (var value2 in Report)
                {
                    if (value1 + value2 == sumOfValues)
                    {
                        return (value1, value2);
                    }
                }
            }

            throw new ApplicationException("No values found!");
        }

        public (int, int, int) FindThreeValuesTotalling(int sumOfValues)
        {
            foreach (var value1 in Report)
            {
                foreach (var value2 in Report)
                {
                    foreach (var value3 in Report)
                    {
                        if (value1 + value2 + value3 == sumOfValues)
                        {
                            return (value1, value2, value3);
                        }
                    }
                }
            }

            throw new ApplicationException("No values found!");
        }

        public static int MultiplyReportValues((int, int) values)
        {
            var (item1, item2) = values;
            return item1 * item2;
        }

        public static int MultiplyReportValues((int, int, int) values)
        {
            var (item1, item2, item3) = values;
            return item1 * item2 * item3;
        }
    }
}