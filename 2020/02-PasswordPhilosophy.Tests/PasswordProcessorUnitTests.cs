using Moq;
using NUnit.Framework;
using PasswordValidator.Policies;
using Tools;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable StringLiteralTypo

namespace PasswordValidator.Tests.PasswordProcessorUnitTests
{
    [TestFixture("1-3 a: abcde|1-3 b: cdefg|2-9 c: ccccccccc", PolicyType.Occurrence, 2)]
    [TestFixture("1-3 a: abcde|1-3 b: cdefg|2-9 c: ccccccccc", PolicyType.Positional, 1)]
    public class When_counting_the_valid_passwords
    {
        private readonly string[] _testData;
        private readonly PolicyType _type;
        private readonly int _expectedResult;

        private PasswordProcessor _processor;

        public When_counting_the_valid_passwords(string input, PolicyType type, int expectedResult)
        {
            _testData = input.Split('|');
            _type = type;
            _expectedResult = expectedResult;
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(_testData);
            _processor = new PasswordProcessor(mockPuzzleInput.Object, new PasswordPolicyFactory());
        }

        [Test]
        public void Then_the_correct_result_is_returned()
        {
            Assert.That(_processor.ValidPasswordsCount(_type), Is.EqualTo(_expectedResult));
        }
    }
}