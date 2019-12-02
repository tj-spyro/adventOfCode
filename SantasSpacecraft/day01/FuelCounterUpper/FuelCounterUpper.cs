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
            return CalculateFuel(ReadModuleMassFromFile(filePath));
        }

        public IEnumerable<int> ReadModuleMassFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            return lines.Select(l => int.Parse(l));
        }

        public int CalculateTotalFuelForModule(int mass)
        {
            var moduleFuel = CalculateFuel(mass);
            var extraFuel = CalculateExtraFuel(moduleFuel);

            return moduleFuel + extraFuel;
        }

        public int CalculateExtraFuel(int fuel)
        {
            var extraFuel = 0;
            while (true)
            {
                fuel = CalculateFuel(fuel);
                if(fuel <= 0)
                {
                    return extraFuel;
                }
                extraFuel += fuel;
            }
        }

        public int CalculateTotalFuelFromFile(string filePath)
        {
            var modules = ReadModuleMassFromFile(filePath);

            return modules.Sum(CalculateTotalFuelForModule);
        }
    }
}
