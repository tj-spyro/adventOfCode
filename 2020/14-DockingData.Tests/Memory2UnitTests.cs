using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace DockingData.Tests.Memory2UnitTests
{
    [TestFixture]
    public class When_summing_memory
    {
        private Memory2 _memory;
        private Mock<IBitMasker> _mockBitMasker;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "mask = 000000000000000000000000000000X1001X",
                "mem[42] = 100",
                "mask = 00000000000000000000000000000000X0XX",
                "mem[26] = 1"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            var sequence = new MockSequence();

            _mockBitMasker = new Mock<IBitMasker>(MockBehavior.Strict);
            _mockBitMasker.InSequence(sequence).Setup(b => b.ApplyMultiple(It.IsAny<string>(), 42))
                .Returns(new long[] {26, 27, 58, 59});
            _mockBitMasker.InSequence(sequence).Setup(b => b.ApplyMultiple(It.IsAny<string>(), 26))
                .Returns(new long[] {16, 17, 18, 19, 24, 25, 26, 27});

            _memory = new Memory2(mockPuzzleInput.Object, _mockBitMasker.Object);

            _memory.Initialise();
        }

        [Test]
        public void Then_the_bitMasker_is_called_correctly()
        {
            _mockBitMasker.Verify(b => b.ApplyMultiple(It.IsAny<string>(), 42));
            _mockBitMasker.Verify(b => b.ApplyMultiple(It.IsAny<string>(), 26));
        }

        [Test]
        public void Then_the_sum_is_correct()
        {
            Assert.That(_memory.Sum(), Is.EqualTo(208));
        }
    }


    [TestFixture]
    public class When_getting_sample1_answer2
    {
        private Memory2 _memory;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "mask = 000000000000000000000000000000X1001X",
                "mem[42] = 100",
                "mask = 00000000000000000000000000000000X0XX",
                "mem[26] = 1"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _memory = new Memory2(mockPuzzleInput.Object, new BitMasker());

            _memory.Initialise();
        }

        [Test]
        public void Then_the_sum_is_correct()
        {
            Assert.That(_memory.Sum(), Is.EqualTo(208));
        }
    }
}