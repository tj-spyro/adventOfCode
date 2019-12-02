using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day01
{
    public class FuelCounterUpper
    {
        public int CalculateFuel(int mass)
        {
            return (int) Math.Floor((decimal)mass / 3) - 2;
        }

        public int CalculateFuel(IEnumerable<int> modules)
        {
            return modules.Sum(CalculateFuel);
        }

        public int CalculateFuelFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            var modules = lines.Select(l => int.Parse(l));

            return CalculateFuel(modules);
        }
    }
}
