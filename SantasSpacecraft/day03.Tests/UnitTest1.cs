using System.IO;
using System.Linq;
using NUnit.Framework;

namespace day03.Tests
{
    public class When_getting_manhattan_distance
    {
        [TestCase(3, 0, 4, 0, 7)]
        [TestCase(3, 5, 3, 10, 9)]
        [TestCase(10, 5, 3, 12, 14)]
        public void Then_distance_is_returned(int x1, int x2, int y1, int y2, int expected)
        {
            var sut = new CrossedWires.CrossedWires();
            var result = sut.GetManhattanDistance(x1, x2, y1, y2);

            Assert.That(result, Is.EqualTo(expected));
        }
    }

    public class When_finding_intersection
    {
        [TestCase("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        [TestCase("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [TestCase("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void Then_then_the_distance_is_found(string input1, string input2, int expectedDistance)
        {
            var sut = new CrossedWires.CrossedWires();
            var result = sut.GetDistanceFromCentralPort(input1, input2);
            Assert.That(result, Is.EqualTo(expectedDistance));
        }
    }

    public class SolveProblem
    {
        [Test]
        public void Get_result()
        {
            var testFilePath = "..//..//..//TestData//input.txt";

            var inputs = File.ReadLines(testFilePath).ToArray();

            var sut = new CrossedWires.CrossedWires();
            var result = sut.GetDistanceFromCentralPort(inputs[0], inputs[1]);

            var expectedDistance = 557;

            Assert.That(result, Is.EqualTo(expectedDistance));
        }
    }
}