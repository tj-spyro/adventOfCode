using System;
using System.Collections.Generic;
// ReSharper disable CheckNamespace

namespace ShuttleSearch
{
    public class Bus
    {
        public int Id { get; private set; }

        public Bus(string id)
        {
            Id = int.Parse(id);
        }

        public IEnumerable<int> GetDepartures(int timestamp, int? range = null)
        {
            var departures = new List<int>();

            var minTimestamp = timestamp - (range ?? Id);
            var maxTimestamp = timestamp + (range ?? Id);

            var nextDeparture = NextDeparture(minTimestamp);
            departures.Add(nextDeparture);

            while (true)
            {
                nextDeparture += Id;

                if (nextDeparture <= maxTimestamp)
                {
                    departures.Add(nextDeparture);
                }
                else
                {
                    break;
                }
            }

            return departures;
        }

        public int NextDeparture(int timestamp)
        {
            var q = Math.DivRem(timestamp, Id, out var m);

            return m == 0 ? timestamp : (q + 1) * Id;
        }

        public int WaitTime(int timestamp)
        {
            return NextDeparture(timestamp) - timestamp;
        }
    }
}