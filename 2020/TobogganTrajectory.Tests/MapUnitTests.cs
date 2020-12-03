using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace TobogganTrajectory.Tests.MapUnitTests
{
    [TestFixture]
    public class When_checking_point_is_a_tree
    {
        [TestCase("#.", true)]
        [TestCase(".#", false)]
        public void The_result_is_correct(string input, bool expectedResult)
        {
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(new []{ input });

            var map = new Map(mockPuzzleInput.Object);

            map.Move(0, 0);

            Assert.That(map.IsTree, Is.EqualTo(expectedResult));
        }
    }

    [TestFixture]
    public class When_moving_down_one
    {
        [TestCase(".#|#.", true)]
        [TestCase("#.|.#", false)]
        public void The_result_is_correct(string input, bool expectedResult)
        {
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(input.Split('|'));

            var map = new Map(mockPuzzleInput.Object);

            map.Move(0, 1);

            Assert.That(map.IsTree, Is.EqualTo(expectedResult));
        }
    }

    [TestFixture]
    public class When_moving_right_one
    {
        [TestCase(".#", true)]
        [TestCase("#.", false)]
        public void The_result_is_correct(string input, bool expectedResult)
        {
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(input.Split('|'));

            var map = new Map(mockPuzzleInput.Object);

            map.Move(1, 0);

            Assert.That(map.IsTree, Is.EqualTo(expectedResult));
        }
    }

    [TestFixture]
    public class When_moving_down_beyond_map
    {
        [TestCase(".|#|.|", 2, true)]
        [TestCase(".|#", 2, false)]
        public void The_result_is_correct(string input,int down, bool expectedResult)
        {
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(input.Split('|'));

            var map = new Map(mockPuzzleInput.Object);

            var result = map.Move(0, down);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }

    [TestFixture]
    public class When_moving_right_beyond_initial_map
    {
        [TestCase(".##|###", 3, false)]
        [TestCase("#..|...", 3, true)]
        public void The_result_is_correct(string input, int right, bool expectedResult)
        {
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(input.Split('|'));

            var map = new Map(mockPuzzleInput.Object);

            map.Move(right, 0);

            Assert.That(map.IsTree, Is.EqualTo(expectedResult));
        }
    }
}