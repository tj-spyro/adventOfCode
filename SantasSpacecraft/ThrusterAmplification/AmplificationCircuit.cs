using System;
using System.Collections.Generic;
using System.Linq;
using Intcode.Memory;

namespace ThrusterAmplification
{
    public class AmplificationCircuit
    {
        private readonly string _program;

        private readonly List<int> _thrusterSignals = new List<int>();

        public int MaxThrusterSignal => _thrusterSignals.Count > 0 ? _thrusterSignals.Max() : 0;

        public AmplificationCircuit(string program)
        {
            _program = program;
        }

        public void Run(int[] phaseSequence)
        {
            var output = 0;
            foreach (var phase in phaseSequence)
            {
                var amplifier = new Amplifier(new IntcodeMemory(_program), phase);

                output = amplifier.Run(output);
            }

            _thrusterSignals.Add(output);
        }

        public void FindHighestSignal()
        {
            var permutations = GetPermutations(new[] {0, 1, 2, 3, 4});

            foreach (var permutation in permutations)
            {
                var p = permutation.ToArray();
                Run(p);
            }
        }

        private static IEnumerable<IEnumerable<int>> GetPermutations(IEnumerable<int> values)
        {
            return (values.Count() == 1)
                ? new[] {values}
                : values.SelectMany(v => GetPermutations(values.Where(x => x.Equals(v) == false)),
                    (v, p) => p.Prepend(v));
        }
    }
}
