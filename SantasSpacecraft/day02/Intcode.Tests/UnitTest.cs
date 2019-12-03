using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Intcode.Tests
{
    public class When_handling_oppcode_1_add
	{
        [Test]
        public void Then_the_numbers_are_added()
		{
			var testString = "1,9,10,3,2,3,11,0,99,30,40,50";

			var sut = new Intcode(testString);

			sut.ProcessState();

			var result = sut.State[3];
			var expected = 70;

			Assert.That(result, Is.EqualTo(expected));
		}
	}

	public class When_handling_oppcode_2_multiply
	{
		[Test]
		public void Then_the_numbers_are_multiplied()
		{
			var testString = "1,9,10,3,2,3,11,0,99,30,40,50";

			var sut = new Intcode(testString);

			sut.ProcessState();

			var result = sut.State[0];
			var expected = 3500;

			Assert.That(result, Is.EqualTo(expected));
		}
	}

    public class StateTests
	{
		[TestCase("1,0,0,0,99", "2,0,0,0,99")]
		[TestCase("2,3,0,3,99", "2,3,0,6,99")]
		[TestCase("2,4,4,5,99,0", "2,4,4,5,99,9801")]
        [TestCase("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        public void StatesAreUpdated(string intitialState, string expectedEndState)
		{
			var sut = new Intcode(intitialState);
			sut.ProcessState();
			var result = string.Join(",", sut.State);

			Assert.That(result, Is.EqualTo(expectedEndState));
		}
	}

    public class When_processing_the_test_state
    {
        private Intcode _intCode;

        [SetUp]
        public void Setup()
        {
            var testFilePath = "..//..//..//TestData//input.txt";

            var initialState = File.ReadLines(testFilePath).First();

            _intCode = new Intcode(initialState);

            _intCode.ResetState();
            _intCode.ProcessState();
        }

        [Test]
        public void Then_result_at_position_zero_is_correct()
        {
            var result = _intCode.State[0];

            Assert.That(result, Is.EqualTo(5110675));
        }
    }
}
