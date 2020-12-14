using System.Drawing;
using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace RainRisk.Tests.NavigatorUnitTests
{
    [TestFixture("F10", 10, 0, Heading.East)]
    [TestFixture("N10", 0, 10, Heading.East)]
    [TestFixture("S10", 0, -10, Heading.East)]
    [TestFixture("E10", 10, 0, Heading.East)]
    [TestFixture("W10", -10, 0, Heading.East)]
    [TestFixture("L90", 0, 0, Heading.North)]
    [TestFixture("R90", 0, 0, Heading.South)]
    [TestFixture("L180", 0, 0, Heading.West)]
    [TestFixture("R180", 0, 0, Heading.West)]
    [TestFixture("L270", 0, 0, Heading.South)]
    [TestFixture("R270", 0, 0, Heading.North)]
    public class When_parsing_single_actions
    {
        private readonly string _input;
        private readonly Point _expectedPosition;
        private readonly Heading _expectedHeading;
        private Navigator _navigator;

        public When_parsing_single_actions(string input, int newX, int newY, Heading expectedHeading)
        {
            _input = input;
            _expectedPosition = new Point(newX, newY);
            _expectedHeading = expectedHeading;
        }

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                _input
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _navigator = new Navigator(mockPuzzleInput.Object);

            _navigator.ExecuteAction(_input);
        }

        [Test]
        public void Then_the_current_position_is_correct()
        {
            Assert.That(_navigator.CurrentPosition, Is.EqualTo(_expectedPosition));
        }

        [Test]
        public void Then_the_direction_facing_is_correct()
        {
            Assert.That(_navigator.Heading, Is.EqualTo(_expectedHeading));
        }
    }

    [TestFixture]
    public class When_getting_sample1_answer1
    {
        private Navigator _navigator;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "F10","N3","F7","R90","F11"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _navigator = new Navigator(mockPuzzleInput.Object);

            _navigator.ExecuteActions();
        }

        [Test]
        public void Then_the_current_position_is_correct()
        {
            Assert.That(_navigator.CurrentPosition, Is.EqualTo(new Point(17,-8)));
        }

        [Test]
        public void Then_the_direction_facing_is_correct()
        {
            Assert.That(_navigator.Heading, Is.EqualTo(Heading.South));
        }

        [Test]
        public void Then_the_manhattan_distance_is_correct()
        {
            Assert.That(_navigator.GetManhattanDistance(), Is.EqualTo(25));
        }
    }
}