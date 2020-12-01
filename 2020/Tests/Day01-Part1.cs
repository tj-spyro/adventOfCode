using ExpenseReport;
using NUnit.Framework;
using PuzzleInput;

namespace Tests.Day01Part1
{
    public class When_given_the_example_list
    {
        private ReportAnalyser _reportAnalyser;

        [SetUp]
        public void Setup()
        {
            var testReport = new[] {1721, 979, 366, 299, 675, 1456};

            _reportAnalyser = new ReportAnalyser(testReport);
        }

        [Test]
        public void Then_the_two_values_are_found()
        {
            Assert.That(_reportAnalyser.FindTwoValuesTotalling(2020), Is.EqualTo((1721, 299)));
        }

        [Test]
        public void Then_the_correct_answer_is_found()
        {
            Assert.That(ReportAnalyser.MultiplyReportValues(_reportAnalyser.FindTwoValuesTotalling(2020)),
                Is.EqualTo(514579));
        }
    }

    public class When_given_the_actual_report
    {
        private ReportAnalyser _reportAnalyser;

        [SetUp]
        public void Setup()
        {
            var reportData = new IntArrayInput().GetData("Data/Day01.txt");

            _reportAnalyser = new ReportAnalyser(reportData);
        }

        [Test]
        public void Then_the_two_values_are_found()
        {
            Assert.That(_reportAnalyser.FindTwoValuesTotalling(2020), Is.EqualTo((1743, 277)));
        }

        [Test]
        public void Then_the_correct_answer_is_found()
        {
            Assert.That(ReportAnalyser.MultiplyReportValues(_reportAnalyser.FindTwoValuesTotalling(2020)),
                Is.EqualTo(482811));
        }
    }
}