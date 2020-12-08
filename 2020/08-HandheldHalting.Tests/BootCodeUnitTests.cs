using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace HandheldHalting.Tests
{
    [TestFixture]
    public class When_getting_sample_answer1
    {
        private BootCode _bootCode;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "nop +0", "acc +1", "jmp +4", "acc +3", "jmp -3", "acc -99", "acc +1", "jmp -4", "acc +6"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _bootCode = new BootCode(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_the_answer_is_correct()
        {
            Assert.That(_bootCode.Answer1(), Is.EqualTo(5));
        }
    }
}