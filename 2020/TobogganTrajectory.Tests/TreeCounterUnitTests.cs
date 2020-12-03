using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace TobogganTrajectory.Tests.TreeCounterUnitTests
{
    [TestFixture]
    public class When_traversing_a_map
    {
        [TestCase(".|#|", 0,1, 1)]
        [TestCase(".|.", 0,1, 0)]
        [TestCase("..##.......|#...#...#..|.#....#..#.|..#.#...#.#|.#...##..#.|..#.##.....|.#.#.#....#|.#........#|#.##...#...|#...##....#|.#..#...#.#|", 3,1, 7)]
        public void Then_all_the_encountered_trees_are_counted(string input, int right, int down, int expectedResult)
        {
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(input.Split('|'));

            var map = new Map(mockPuzzleInput.Object);

            var sut = new TreeCounter(map);

            var result = sut.Run(right, down);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}