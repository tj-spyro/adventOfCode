using System.Linq;
using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable CheckNamespace

namespace EncodingError.Tests.XmasDecoderUnitTests
{
    [TestFixture("26", true)]
    [TestFixture("49", true)]
    [TestFixture("100", false)]
    [TestFixture("50", false)]
    public class When_validating_a_number
    {
        private readonly string _testNumber;
        private readonly bool _expectedResult;
        private XmasDecoder _decoder;

        public When_validating_a_number(string testNumber, bool expectedResult)
        {
            _testNumber = testNumber;
            _expectedResult = expectedResult;
        }

        [SetUp]
        public void Setup()
        {
            var baseInput = Enumerable.Range(1, 25).Select(i => i.ToString()).ToList();
            baseInput.Add(_testNumber);

            var testData = baseInput.ToArray();

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _decoder = new XmasDecoder(mockPuzzleInput.Object);
        }

        [Test]
        public void The_response_is_correct()
        {
            Assert.That(_decoder.ValidNumber(25,25), Is.EqualTo(_expectedResult));
        }
    }

    public class When_getting_sample_answer1
    {
        private XmasDecoder _decoder;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "35", "20", "15", "25", "47", "40", "62", "55", "65", "95", "102", "117", "150", "182", "127", "219",
                "299", "277", "309", "576"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _decoder = new XmasDecoder(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_the_answer_is_correct()
        {
            Assert.That(_decoder.FindFirstInvalidNumber(5), Is.EqualTo(127));
        }
    }

    public class When_getting_sample_answer2
    {
        private XmasDecoder _decoder;
        private (bool found, long min, long max) _set;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "35", "20", "15", "25", "47", "40", "62", "55", "65", "95", "102", "117", "150", "182", "127", "219",
                "299", "277", "309", "576"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _decoder = new XmasDecoder(mockPuzzleInput.Object);

            _set = _decoder.FindContiguousSet(_decoder.FindFirstInvalidNumber(5), 2);
        }

        [Test]
        public void Then_the_set_min_is_correct()
        {
            Assert.That(_set.min, Is.EqualTo(15));
        }

        [Test]
        public void Then_the_set_max_is_correct()
        {
            Assert.That(_set.max, Is.EqualTo(47));
        }

        [Test]
        public void Then_the_answer_is_correct()
        {
            Assert.That(_decoder.FindEncryptionWeakness(5), Is.EqualTo(62));
        }
    }
}