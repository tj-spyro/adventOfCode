using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace DockingData.Tests.MemoryUnitTests
{
    [TestFixture]
    public class When_summing_memory
    {
        private Memory _memory;
        private Mock<IBitMasker> _mockBitMasker;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "mem[8] = 11",
                "mem[7] = 101",
                "mem[8] = 0"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            var sequence = new MockSequence();

            _mockBitMasker = new Mock<IBitMasker>(MockBehavior.Strict);
            _mockBitMasker.InSequence(sequence).Setup(b => b.Apply(It.IsAny<string>(), 11)).Returns(73);
            _mockBitMasker.InSequence(sequence).Setup(b => b.Apply(It.IsAny<string>(), 101)).Returns(101);
            _mockBitMasker.InSequence(sequence).Setup(b => b.Apply(It.IsAny<string>(), 0)).Returns(64);

            _memory = new Memory(mockPuzzleInput.Object, _mockBitMasker.Object);

            _memory.Initialise();
        }

        [Test]
        public void Then_the_bitMasker_is_called_correctly()
        {
            _mockBitMasker.Verify(b => b.Apply(It.IsAny<string>(), 11));
            _mockBitMasker.Verify(b => b.Apply(It.IsAny<string>(), 101));
            _mockBitMasker.Verify(b => b.Apply(It.IsAny<string>(), 0));
        }

        [Test]
        public void Then_the_sum_is_correct()
        {
            Assert.That(_memory.Sum(), Is.EqualTo(165));
        }
    }


    [TestFixture]
    public class When_getting_sample1_answer1
    {
        private Memory _memory;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "mem[8] = 11",
                "mem[7] = 101",
                "mem[8] = 0"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _memory = new Memory(mockPuzzleInput.Object, new BitMasker());

            _memory.Initialise();
        }

        [Test]
        public void Then_the_sum_is_correct()
        {
            Assert.That(_memory.Sum(), Is.EqualTo(165));
        }
    }
}