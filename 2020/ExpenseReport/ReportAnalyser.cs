using System;

namespace ExpenseReport
{
    public class ReportAnalyser
    {
        private readonly int[] _report;

        public ReportAnalyser(int[] report)
        {
            _report = report;
        }

        public (int, int) FindTwoValuesTotalling(int sumOfValues)
        {
            foreach (var value1 in _report)
            {
                foreach (var value2 in _report)
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
            foreach (var value1 in _report)
            {
                foreach (var value2 in _report)
                {
                    foreach (var value3 in _report)
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