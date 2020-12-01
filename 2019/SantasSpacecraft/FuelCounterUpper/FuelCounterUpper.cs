using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FuelCounterUpper
{
    public class FuelCounterUpper
    {
        public static int CalculateFuel(int mass)
        {
            return (int) Math.Floor((decimal)mass / 3) - 2;
        }

        public static int CalculateFuel(IEnumerable<int> modules)
        {
            return modules.Sum(CalculateFuel);
        }

        public int CalculateFuelFromFile(string filePath)
        {
            return CalculateFuel(ReadModuleMassFromFile(filePath));
        }

        private IEnumerable<int> ReadModuleMassFromFile(string filePath)
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

        public static int CalculateExtraFuel(int fuel)
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
