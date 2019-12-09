﻿using System.IO;
using System.Linq;
using Intcode;
using Intcode.Memory;
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

        [Test]
        public void Part_2()
        {
            
        }
    }
}
