using Moq;
using NUnit.Framework;
using Tools;
// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

namespace ExpenseReport.Tests.ReportAnalyserUnitTests
{
    public class When_looking_for_two_numbers
    {
        private ReportAnalyser _reportAnalyser;

        [SetUp]
        public void Setup()
        {
            var testReport = new[] { "1721", "979", "366", "299", "675", "1456" };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testReport);

            _reportAnalyser = new ReportAnalyser(mockPuzzleInput.Object);
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

    public class When_looking_for_three_numbers
    {
        private ReportAnalyser _reportAnalyser;

        [SetUp]
        public void Setup()
        {
            var testReport = new[] { "1721", "979", "366", "299", "675", "1456" };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testReport);

            _reportAnalyser = new ReportAnalyser(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_the_two_values_are_found()
        {
            Assert.That(_reportAnalyser.FindThreeValuesTotalling(2020), Is.EqualTo((979, 366, 675)));
        }

        [Test]
        public void Then_the_correct_answer_is_found()
        {
            Assert.That(ReportAnalyser.MultiplyReportValues(_reportAnalyser.FindThreeValuesTotalling(2020)),
                Is.EqualTo(241861950));
        }
    }
}