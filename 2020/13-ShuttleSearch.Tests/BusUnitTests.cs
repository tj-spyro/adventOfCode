using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace ShuttleSearch.Tests.BusUnitTests
{
    [TestFixture(939, "7", "931|938|945", 945, 6)]
    [TestFixture(939, "13", "936|949", 949, 10)]
    [TestFixture(939, "59", "944", 944, 5)]
    [TestFixture(939, "31", "930", 961, 22)]
    [TestFixture(939, "19", "931", 950, 11)]
    public class When_getting_bus_information
    {
        private readonly int _timestamp;
        private readonly string _busId;
        private readonly IEnumerable<int> _expectedDepartures;
        private readonly int _nextDeparture;
        private readonly int _waitTime;

        private Bus _bus;

        public When_getting_bus_information(int timestamp, string busId, string expectedDepartures, int nextDeparture, int waitTime)
        {
            _timestamp = timestamp;
            _busId = busId;
            _expectedDepartures = expectedDepartures.Split('|').Select(int.Parse);
            _nextDeparture = nextDeparture;
            _waitTime = waitTime;
        }

        [SetUp]
        public void Setup()
        {
            _bus = new Bus(_busId);
        }

        [Test]
        public void Then_the_expected_departures_are_correct()
        {
            Assert.That(_bus.GetDepartures(_timestamp, 10).SequenceEqual(_expectedDepartures));
        }

        [Test]
        public void Then_the_next_departure_is_correct()
        {
            Assert.That(_bus.NextDeparture(_timestamp), Is.EqualTo(_nextDeparture));
        }

        [Test]
        public void Then_the_wait_time_is_correct()
        {
            Assert.That(_bus.WaitTime(_timestamp), Is.EqualTo(_waitTime));
        }
    }
}