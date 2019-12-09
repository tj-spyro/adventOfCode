using System.IO;
using System.Linq;
using Intcode;
using Intcode.Memory;
using NUnit.Framework;

namespace SantasSpacecraft.Tests.Day05
{
    public class When_handling_oppcodes_3_and_4
	{
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(10)]
        public void Then_the_input_is_outputted(int input)
		{
			var testString = "3,0,4,0,99";
            var memory = new IntcodeMemory(testString);
			var sut = new Intcode.Intcode(memory, input);

			sut.ProcessInstructions();

			Assert.That(sut.Output, Is.EqualTo(input));
		}
	}

    public class When_evaluting_oppcode
    {
        [TestCase(10099, ExpectedResult = OppCode.Terminate)]
        [TestCase(10001, ExpectedResult = OppCode.Add)]
        [TestCase(10002, ExpectedResult = OppCode.Multiply)]
        [TestCase(10003, ExpectedResult = OppCode.Input)]
        [TestCase(10004, ExpectedResult = OppCode.Output)]
        [TestCase(01099, ExpectedResult = OppCode.Terminate)]
        [TestCase(01001, ExpectedResult = OppCode.Add)]
        [TestCase(01002, ExpectedResult = OppCode.Multiply)]
        [TestCase(01003, ExpectedResult = OppCode.Input)]
        [TestCase(01004, ExpectedResult = OppCode.Output)]
        [TestCase(00199, ExpectedResult = OppCode.Terminate)]
        [TestCase(00101, ExpectedResult = OppCode.Add)]
        [TestCase(00102, ExpectedResult = OppCode.Multiply)]
        [TestCase(00103, ExpectedResult = OppCode.Input)]
        [TestCase(00104, ExpectedResult = OppCode.Output)]
        public OppCode Then_correct_enum_is_returned(int input)
        {
            return Intcode.Intcode.GetOppCode(input);
        }
    }

    public class When_evaluting_parameter_mode
    {
        [TestCase(99, ExpectedResult = new[]{ Mode.Position, Mode.Position, Mode.Position})]
        [TestCase(1, ExpectedResult =  new[]{ Mode.Position, Mode.Position, Mode.Position})]
        [TestCase(2, ExpectedResult =  new[]{ Mode.Position, Mode.Position, Mode.Position})]
        [TestCase(3, ExpectedResult =  new[]{ Mode.Position, Mode.Position, Mode.Position})]
        [TestCase(4, ExpectedResult =  new[]{ Mode.Position, Mode.Position, Mode.Position})]
        [TestCase(10099, ExpectedResult = new[]{ Mode.Position, Mode.Position, Mode.Immediate})]
        [TestCase(10001, ExpectedResult = new[]{ Mode.Position, Mode.Position, Mode.Immediate})]
        [TestCase(10002, ExpectedResult = new[]{ Mode.Position, Mode.Position, Mode.Immediate})]
        [TestCase(10003, ExpectedResult = new[]{ Mode.Position, Mode.Position, Mode.Immediate})]
        [TestCase(10004, ExpectedResult = new[]{ Mode.Position, Mode.Position, Mode.Immediate})]
        [TestCase(01099, ExpectedResult = new[]{ Mode.Position, Mode.Immediate, Mode.Position})]
        [TestCase(01001, ExpectedResult = new[]{ Mode.Position, Mode.Immediate, Mode.Position})]
        [TestCase(01002, ExpectedResult = new[]{ Mode.Position, Mode.Immediate, Mode.Position})]
        [TestCase(01003, ExpectedResult = new[]{ Mode.Position, Mode.Immediate, Mode.Position})]
        [TestCase(01004, ExpectedResult = new[]{ Mode.Position, Mode.Immediate, Mode.Position})]
        [TestCase(00199, ExpectedResult = new[]{ Mode.Immediate, Mode.Position, Mode.Position})]
        [TestCase(00101, ExpectedResult = new[]{ Mode.Immediate, Mode.Position, Mode.Position})]
        [TestCase(00102, ExpectedResult = new[]{ Mode.Immediate, Mode.Position, Mode.Position})]
        [TestCase(00103, ExpectedResult = new[]{ Mode.Immediate, Mode.Position, Mode.Position})]
        [TestCase(00104, ExpectedResult = new[]{ Mode.Immediate, Mode.Position, Mode.Position})]
        public Mode[] Then_correct_enum_is_returned(int input)
        {
            return Intcode.Intcode.GetParameterModes(input);
        }
    }

    public class When_getting_instruction
    {
        [TestCase("1", OppCode.Add, Mode.Position, Mode.Position, Mode.Position)]
        [TestCase("2", OppCode.Multiply, Mode.Position, Mode.Position, Mode.Position)]
        [TestCase("3", OppCode.Input, Mode.Position, Mode.Position, Mode.Position)]
        [TestCase("4", OppCode.Output, Mode.Position, Mode.Position, Mode.Position)]
        [TestCase("10099", OppCode.Terminate , Mode.Position, Mode.Position, Mode.Immediate)]
        [TestCase("10001", OppCode.Add, Mode.Position, Mode.Position, Mode.Immediate)]
        [TestCase("10002", OppCode.Multiply, Mode.Position, Mode.Position, Mode.Immediate)]
        [TestCase("10003", OppCode.Input, Mode.Position, Mode.Position, Mode.Immediate)]
        [TestCase("10004", OppCode.Output, Mode.Position, Mode.Position, Mode.Immediate)]
        [TestCase("01099", OppCode.Terminate, Mode.Position, Mode.Immediate, Mode.Position)]
        [TestCase("01001", OppCode.Add, Mode.Position, Mode.Immediate, Mode.Position)]
        [TestCase("01002", OppCode.Multiply, Mode.Position, Mode.Immediate, Mode.Position)]
        [TestCase("01003", OppCode.Input, Mode.Position, Mode.Immediate, Mode.Position)]
        [TestCase("01004", OppCode.Output, Mode.Position, Mode.Immediate, Mode.Position)]
        [TestCase("00199", OppCode.Terminate, Mode.Immediate, Mode.Position, Mode.Position)]
        [TestCase("00101", OppCode.Add, Mode.Immediate, Mode.Position, Mode.Position)]
        [TestCase("00102", OppCode.Multiply, Mode.Immediate, Mode.Position, Mode.Position)]
        [TestCase("00103", OppCode.Input, Mode.Immediate, Mode.Position, Mode.Position)]
        [TestCase("00104", OppCode.Output, Mode.Immediate, Mode.Position, Mode.Position)]
        public void Then_correct_enum_is_returned(string input, OppCode expectedOppCode, Mode expectedMode0, Mode expectedMode1, Mode expectedMode2)
        {
            var memory = new IntcodeMemory(input);
            var intcode = new Intcode.Intcode(memory);
            var (oppCode, modes) = intcode.GetInstruction();

            Assert.That(oppCode, Is.EqualTo(expectedOppCode));
            Assert.That(modes[0], Is.EqualTo(expectedMode0));
            Assert.That(modes[1], Is.EqualTo(expectedMode1));
            Assert.That(modes[2], Is.EqualTo(expectedMode2));
        }
    }

    public class Solve_Part1
    {
        [Test]
        public void Then_answer()
        {
            var testFilePath = "..//..//..//TestData//day05.txt";

            var initialState = File.ReadLines(testFilePath).First();
            var memory = new IntcodeMemory(initialState);

            var intcodeComputer = new Intcode.Intcode(memory,1);

            intcodeComputer.ProcessInstructions();
            var result = intcodeComputer.Output();

            Assert.That(result, Is.EqualTo(9938601));
        }
    }

    [TestFixture]
    public class Solve_Part2
    {
        [Test]
        public void Then_answer()
        {
            var testFilePath = "..//..//..//TestData//day05.txt";

            var initialState = File.ReadLines(testFilePath).First();
            var memory = new IntcodeMemory(initialState);

            var intcodeComputer = new Intcode.Intcode(memory,5);

            intcodeComputer.ProcessInstructions();
            var result = intcodeComputer.Output();

            Assert.That(result, Is.EqualTo(4283952));
        }
    }
}
