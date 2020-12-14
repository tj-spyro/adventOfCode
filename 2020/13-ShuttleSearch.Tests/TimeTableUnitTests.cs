using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace ShuttleSearch.Tests.TimeTableUnitTests
{
    [TestFixture]
    public class When_getting_sample1_answer1
    {
        private TimeTable _timeTable;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "939","7,13,x,x,59,x,31,19"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _timeTable = new TimeTable(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_the_next_departure_is_correct()
        {
            Assert.That(_timeTable.NextDeparture(), Is.EqualTo(944));
        }

        [Test]
        public void Then_the_wait_time_is_correct()
        {
            Assert.That(_timeTable.WaitTime(), Is.EqualTo(5));
        }

        [Test]
        public void Then_answer1_is_correct()
        {
            Assert.That(_timeTable.Solve1(), Is.EqualTo(295));
        }
    }
}