using System.IO;
using System.Linq;
using NUnit.Framework;
using OrbitalComputer;

namespace SantasSpacecraft.Tests.Day06
{
    public class When_populating_orbits
    {
        private readonly string[] _testInput = new[]
            {"COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L"};
        
        [TestCase("D", ExpectedResult = 3)]
        [TestCase("L", ExpectedResult = 7)]
        [TestCase("COM", ExpectedResult = 0)]
        public int Then_count_is_correct(string orbiter)
        {
            var orbitComputer = new OrbitComputer(_testInput);
            orbitComputer.Initialise();

            return orbitComputer.PopulateIndirectOrbits(orbiter).Count;
        }
    }

    public class When_calculating_orbital_transfers
    {
        private readonly string[] _testInput = new[]
            {"COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L", "K)YOU", "I)SAN"};
        
        [TestCase("YOU", "SAN", ExpectedResult = 4)]
        public int Then_count_is_correct(string from, string to)
        {
            var orbitComputer = new OrbitComputer(_testInput);
            orbitComputer.Initialise();

            return orbitComputer.CalculateOrbitalTransfers(from, to);
        }
    }

    [TestFixture]
    public class Solve
    {
        private string[] _testInput;

        [OneTimeSetUp]
        public void SetUp()
        {
            const string testFilePath = "..//..//..//TestData//day06.txt";

            _testInput = File.ReadLines(testFilePath).ToArray();
        }

        [Test]
        public void Part_1()
        {
            var orbitComputer = new OrbitComputer(_testInput);
            orbitComputer.Initialise();

            var result = orbitComputer.CalculateMapDataChecksum();

            Assert.That(result, Is.EqualTo(453028));
        }

        [TestCase("YOU", "SAN")]
        public void Part_2(string from, string to)
        {
            var orbitComputer = new OrbitComputer(_testInput);
            orbitComputer.Initialise();

            var result = orbitComputer.CalculateOrbitalTransfers(from, to);

            Assert.That(result, Is.EqualTo(562));
        }
    }
}
