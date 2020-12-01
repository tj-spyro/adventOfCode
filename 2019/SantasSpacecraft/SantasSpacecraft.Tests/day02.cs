using System.IO;
using System.Linq;
using Intcode.Memory;
using NUnit.Framework;

namespace SantasSpacecraft.Tests.Day02
{
    public class When_handling_oppcode_1_add
	{
        [Test]
        public void Then_the_numbers_are_added()
		{
			var testString = "1,9,10,3,2,3,11,0,99,30,40,50";
            var memory = new IntcodeMemory(testString);
			var sut = new Intcode.Intcode(memory);

			sut.ProcessInstructions();

			var result = memory.GetValue(3);
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
            var memory = new IntcodeMemory(testString);
            var sut = new Intcode.Intcode(memory);

			sut.ProcessInstructions();

			var result = memory.GetValue(0);
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
        public void StatesAreUpdated(string initialState, string expectedEndState)
		{
            var memory = new IntcodeMemory(initialState);
            var sut = new Intcode.Intcode(memory);
			sut.ProcessInstructions();
			var result = string.Join(",", memory.GetState());

			Assert.That(result, Is.EqualTo(expectedEndState));
		}
	}

    public class When_processing_the_test_state
    {
        private IntcodeMemory _memory;

        [SetUp]
        public void Setup()
        {
            var testFilePath = "..//..//..//TestData//day02.txt";

            var initialState = File.ReadLines(testFilePath).First();
            _memory = new IntcodeMemory(initialState);

            _memory.SetValue(1, 12);
            _memory.SetValue(2, 2);

            var intCode = new Intcode.Intcode(_memory);
            intCode.ProcessInstructions();
        }

        [Test]
        public void Then_result_at_position_zero_is_correct()
        {
            var result = _memory.GetValue(0);

            Assert.That(result, Is.EqualTo(5110675));
        }
    }

    [Ignore("Day05 breaks this")]
    public class When_finding_the_correct_noun_verb_combination
    {
        private Intcode.Intcode _intCode;
        private IntcodeMemory _memory;
        private readonly int _expectedOutput = 19690720;

        [Test]
        public void Then_result_at_position_zero_is_correct()
        {
            var testFilePath = "..//..//..//TestData//day02.txt";

            var initialState = File.ReadLines(testFilePath).First();

            _memory = new IntcodeMemory(initialState);

            _intCode = new Intcode.Intcode(_memory);

            var nounVerb = _intCode.FindNounVerb(_expectedOutput);

            var result = _memory.GetValue(0);

            Assert.That(result, Is.EqualTo(_expectedOutput));

            Assert.That(nounVerb, Is.EqualTo(4847));
        }
    }
}
