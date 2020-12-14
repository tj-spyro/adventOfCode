using System.Drawing;
using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace RainRisk.Tests.WaypointNavigatorUnitTests
{
    [TestFixture("F10", 100, 10, 10, 1)]
    [TestFixture("N10", 0, 0, 10, 11)]
    [TestFixture("S10", 0, 0, 10, -9)]
    [TestFixture("E10", 0, 0, 20, 1)]
    [TestFixture("W10", 0, 0, 0, 1)]
    [TestFixture("L90", 0, 0, -1, 10)]
    [TestFixture("R90", 0, 0, 1, -10)]
    [TestFixture("L180", 0, 0, -10, -1)]
    [TestFixture("R180", 0, 0, -10, -1)]
    [TestFixture("L270", 0, 0, 1, -10)]
    [TestFixture("R270", 0, 0, -1, 10)]
    public class When_parsing_single_actions
    {
        private readonly string _input;
        private readonly Point _expectedPosition;
        private readonly Point _expectedWaypoint;
        private WaypointNavigator _navigator;

        public When_parsing_single_actions(string input, int positionX, int positionY, int waypointX, int waypointY)
        {
            _input = input;
            _expectedPosition = new Point(positionX, positionY);
            _expectedWaypoint = new Point(waypointX, waypointY);
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

            _navigator = new WaypointNavigator(mockPuzzleInput.Object);

            _navigator.ExecuteAction(_input);
        }

        [Test]
        public void Then_the_current_position_is_correct()
        {
            Assert.That(_navigator.CurrentPosition, Is.EqualTo(_expectedPosition));
        }

        [Test]
        public void Then_the_waypoint_position_is_correct()
        {
            Assert.That(_navigator.Waypoint, Is.EqualTo(_expectedWaypoint));
        }
    }

    [TestFixture]
    public class When_getting_sample1_answer2_observed
    {
        private WaypointNavigator _navigator;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "F10","N3","F7","R90","F11"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _navigator = new WaypointNavigator(mockPuzzleInput.Object);

            var i = 0;

            // F10
            _navigator.ExecuteAction(testData[i]);
            Assume.That(_navigator.CurrentPosition, Is.EqualTo(new Point(100, 10)));
            Assume.That(_navigator.Waypoint, Is.EqualTo(new Point(10, 1)));
            i++;

            // N3
            _navigator.ExecuteAction(testData[i]);
            Assume.That(_navigator.CurrentPosition, Is.EqualTo(new Point(100, 10)));
            Assume.That(_navigator.Waypoint, Is.EqualTo(new Point(10, 4)));
            i++;

            // F7
            _navigator.ExecuteAction(testData[i]);
            Assume.That(_navigator.CurrentPosition, Is.EqualTo(new Point(170, 38)));
            Assume.That(_navigator.Waypoint, Is.EqualTo(new Point(10, 4)));
            i++;

            // R90
            _navigator.ExecuteAction(testData[i]);
            Assume.That(_navigator.CurrentPosition, Is.EqualTo(new Point(170, 38)));
            Assume.That(_navigator.Waypoint, Is.EqualTo(new Point(4, -10)));
            i++;

            // F11
            _navigator.ExecuteAction(testData[i]);
            Assume.That(_navigator.CurrentPosition, Is.EqualTo(new Point(214, -72)));
            Assume.That(_navigator.Waypoint, Is.EqualTo(new Point(4, -10)));
        }

        [Test]
        public void Then_the_current_position_is_correct()
        {
            Assert.That(_navigator.CurrentPosition, Is.EqualTo(new Point(214,-72)));
        }

        [Test]
        public void Then_the_waypoint_position_is_correct()
        {
            Assert.That(_navigator.Waypoint, Is.EqualTo(new Point(4, -10)));
        }

        [Test]
        public void Then_the_manhattan_distance_is_correct()
        {
            Assert.That(_navigator.GetManhattanDistance(), Is.EqualTo(286));
        }
    }

    [TestFixture]
    public class When_getting_sample1_answer2
    {
        private WaypointNavigator _navigator;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "F10","N3","F7","R90","F11"
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _navigator = new WaypointNavigator(mockPuzzleInput.Object);

            _navigator.ExecuteActions();
        }

        [Test]
        public void Then_the_current_position_is_correct()
        {
            Assert.That(_navigator.CurrentPosition, Is.EqualTo(new Point(214, -72)));
        }

        [Test]
        public void Then_the_waypoint_position_is_correct()
        {
            Assert.That(_navigator.Waypoint, Is.EqualTo(new Point(4, -10)));
        }

        [Test]
        public void Then_the_manhattan_distance_is_correct()
        {
            Assert.That(_navigator.GetManhattanDistance(), Is.EqualTo(286));
        }
    }
}