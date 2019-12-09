using System.IO;
using System.Linq;
using NUnit.Framework;
using OrbitalComputer;
using ThrusterAmplification;

namespace SantasSpacecraft.Tests.Day07
{
    public class When_calcultaing_max_thrust_signal
    {
        [TestCase("3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0", new[]{4,3,2,1,0}, ExpectedResult = 43210)]
        [TestCase("3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0", new[]{0,1,2,3,4}, ExpectedResult = 54321)]
        [TestCase("3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0", new[]{1,0,4,3,2}, ExpectedResult = 65210)]
        public int Then_max_is_correct(string program, int[] phaseSequence)
        {
            var amplificationCircuit = new AmplificationCircuit(program);

            amplificationCircuit.Run(phaseSequence);

            return amplificationCircuit.MaxThrusterSignal;
        }
    }

    [TestFixture]
    public class Solve
    {
        private string _testInput;

        [OneTimeSetUp]
        public void SetUp()
        {
            const string testFilePath = "..//..//..//TestData//day07.txt";

            _testInput = File.ReadLines(testFilePath).First();
        }

        [Test]
        public void Part_1()
        {
            var amplificationCircuit = new AmplificationCircuit(_testInput);

            amplificationCircuit.FindHighestSignal();

            var result = amplificationCircuit.MaxThrusterSignal;

            Assert.That(result, Is.EqualTo(17406));
        }

        public void Part_2()
        {
            
        }
    }
}
