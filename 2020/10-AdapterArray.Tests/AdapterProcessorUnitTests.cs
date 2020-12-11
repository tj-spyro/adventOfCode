using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace AdapterArray.Tests.AdapterProcessorUnitTests
{
    [TestFixture]
    public class When_getting_sample1_answer1
    {
        private AdapterProcessor _processor;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "16","10","15","5","1","11","7","19","6","12","4"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _processor = new AdapterProcessor(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_the_answer_is_correct()
        {
            Assert.That(_processor.Solve1(), Is.EqualTo(35));
        }
    }

    [TestFixture]
    public class When_getting_sample2_answer1
    {
        private AdapterProcessor _processor;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "28", "33", "18", "42", "31", "14", "46", "20", "48", "47", "24", "23", "49", "45", "19", "38", "39",
                "11", "1", "32", "25", "35", "8", "17", "7", "9", "4", "2", "34", "10", "3"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _processor = new AdapterProcessor(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_the_answer_is_correct()
        {
            Assert.That(_processor.Solve1(), Is.EqualTo(220));
        }
    }

    [TestFixture]
    public class When_getting_sample1_answer2
    {
        private AdapterProcessor _processor;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "16","10","15","5","1","11","7","19","6","12","4"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _processor = new AdapterProcessor(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_the_answer_is_correct()
        {
            Assert.That(_processor.Solve2(), Is.EqualTo(8));
        }
    }

    [TestFixture]
    public class When_getting_sample2_answer2
    {
        private AdapterProcessor _processor;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "28", "33", "18", "42", "31", "14", "46", "20", "48", "47", "24", "23", "49", "45", "19", "38", "39",
                "11", "1", "32", "25", "35", "8", "17", "7", "9", "4", "2", "34", "10", "3"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _processor = new AdapterProcessor(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_the_answer_is_correct()
        {
            Assert.That(_processor.Solve2(), Is.EqualTo(19208));
        }
    }
}