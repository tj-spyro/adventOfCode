using System;
using System.Collections.Generic;
using System.Linq;

namespace OrbitalComputer
{
    public class OrbitComputer
    {
        private readonly string[] _input;

        private const string OrbitDelimiter = ")";

        private const string UniversalCentreOfMass = "COM";

        private Dictionary<string, (string direct, List<string> indirect)> _orbits;

        public OrbitComputer(string[] input)
        {
            _input = input;
        }

        public void Initialise()
        {
            if (_orbits != null)
            {
                return;
            }
            _orbits = new Dictionary<string, (string direct, List<string> inDirect)>();
            foreach (var s in _input)
            {
                var orbiter = s.Substring(s.IndexOf(OrbitDelimiter, StringComparison.Ordinal) + 1);
                var orbitee = s.Substring(0, s.IndexOf(OrbitDelimiter, StringComparison.Ordinal));

                _orbits.Add(orbiter, (orbitee, new List<string>()));
            }

            foreach (var orbit in _orbits)
            {
                PopulateIndirectOrbits(orbit.Key);
            }
        }

        public int CalculateMapDataChecksum()
        {
            Initialise();

            return _orbits.Sum(o => o.Value.indirect.Count);
        }

        public int CalculateOrbitalTransfers(string from, string to)
        {
            Initialise();

            var fromOrbits = _orbits[from].indirect;
            var toOrbits = _orbits[to].indirect;

            var totalOrbits = fromOrbits.Concat(toOrbits).ToList();

            var sharedOrbits = totalOrbits.GroupBy(o => o).Where(g => g.Count() > 1).Sum(g => g.Count());

            return totalOrbits.Count - sharedOrbits - 2;
        }

        public List<string> PopulateIndirectOrbits(string orbiter)
        {
            if (orbiter == UniversalCentreOfMass)
            {
                return new List<string>();
            }

            var indirects = _orbits[orbiter].indirect;

            for (var o = orbiter; _orbits.ContainsKey(o); o = _orbits[o].direct)
            {
                indirects.Add(o);
            }

            return indirects;
        }
    }
}
