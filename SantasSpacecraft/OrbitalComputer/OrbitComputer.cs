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

        private Dictionary<string, (string direct, List<string> indirect)> orbits;

        public OrbitComputer(string[] input)
        {
            _input = input;
        }

        public void Initialise()
        {
            if (orbits != null)
            {
                return;
            }
            orbits = new Dictionary<string, (string direct, List<string> inDirect)>();
            foreach (var s in _input)
            {
                var orbiter = s.Substring(s.IndexOf(OrbitDelimiter, StringComparison.Ordinal) + 1);
                var orbitee = s.Substring(0, s.IndexOf(OrbitDelimiter, StringComparison.Ordinal));

                orbits.Add(orbiter, (orbitee, new List<string>()));
            }
        }

        public int CalculateMapDataChecksum()
        {
            Initialise();

            foreach (var orbit in orbits)
            {
                PopulateIndirectOrbits(orbit.Key);
            }

            return orbits.Sum(o => o.Value.indirect.Count);
        }

        public List<string> PopulateIndirectOrbits(string orbiter)
        {
            if (orbiter == UniversalCentreOfMass)
            {
                return new List<string>();
            }

            var indirects = orbits[orbiter].indirect;

            for (var o = orbiter; orbits.ContainsKey(o); o = orbits[o].direct)
            {
                indirects.Add(o);
            }

            return indirects;
        }
    }
}
