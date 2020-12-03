using System.IO.Abstractions;
using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable CheckNamespace
namespace ToolsTests.PuzzleInputTests
{
    /// <summary>
    /// Testing is not straightforward for this, without going into too much work for a fun project
    /// I am assuming that if GetPuzzleInputAsArray is correct, then GetPuzzleInput is also correct
    /// It does require the cookie to already be set in the correct location
    /// First step on finding a failing test => check the cookie is correct!!
    /// </summary>
    [TestFixture]
    public class When_running_get_puzzle_input_as_array_for_first_data
    {
        private string[] _returns;

        [SetUp]
        public void SetUp()
        {
            var mockConsoleTools = new Mock<IConsoleTools>();
            mockConsoleTools.Setup(c => c.GetStr(It.IsAny<string>())).Returns("File Does not exist, so we need some duff text here to stop it hanging!");
            
            var sut = new PuzzleInput(new CookieRequestor(new FileHandler(new FileSystem()), mockConsoleTools.Object));
            _returns = sut.GetPuzzleInputAsArray("https://adventofcode.com/2020/day/1/input");
        }
        
        [Test]
        public void Then_the_correct_number_of_entries_are_returned()
        {
            Assert.That(_returns.Length, Is.EqualTo(201));
        }
    }
}