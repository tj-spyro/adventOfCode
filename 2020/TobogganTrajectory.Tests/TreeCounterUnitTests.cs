using NUnit.Framework;
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
            var map = new Map(input.Split('|'));

            var sut = new TreeCounter(map);

            var result = sut.Run(right, down);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}