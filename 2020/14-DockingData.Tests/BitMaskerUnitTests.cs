using System.Linq;
using NUnit.Framework;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace DockingData.Tests.BitMaskerUnitTests
{

    [TestFixture("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 11, 73)]
    [TestFixture("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 101, 101)]
    [TestFixture("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 0, 64)]
    public class When_applying_a_bitmask
    {
        private readonly string _bitmask;
        private readonly long _input;
        private readonly long _expectedResult;

        private BitMasker _bitMasker;

        public When_applying_a_bitmask(string bitmask, long input, long expectedResult)
        {
            _bitmask = bitmask;
            _input = input;
            _expectedResult = expectedResult;
        }
        
        [SetUp]
        public void Setup()
        {
            _bitMasker = new BitMasker();
        }

        [Test]
        public void Then_the_result_is_correct()
        {
            Assert.That(_bitMasker.Apply(_bitmask, _input), Is.EqualTo(_expectedResult));
        }
    }

    [TestFixture("000000000000000000000000000000X1001X", 42, "26|27|58|59")]
    [TestFixture("00000000000000000000000000000000X0XX", 26, "16|17|18|19|24|25|26|27")]
    public class When_applying_multiple_bitmask
    {
        private readonly string _bitmask;
        private readonly long _input;
        private readonly long[] _expectedResult;

        private BitMasker _bitMasker;

        public When_applying_multiple_bitmask(string bitmask, long input, string expectedResult)
        {
            _bitmask = bitmask;
            _input = input;
            _expectedResult = expectedResult.Split('|').Select(long.Parse).ToArray();
        }

        [SetUp]
        public void Setup()
        {
            _bitMasker = new BitMasker();
        }

        [Test]
        public void Then_the_result_is_correct()
        {
            Assert.That(_bitMasker.ApplyMultiple(_bitmask, _input).SequenceEqual(_expectedResult));
        }
    }
}