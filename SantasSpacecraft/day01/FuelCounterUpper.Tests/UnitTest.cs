using System.Linq;
using NUnit.Framework;

namespace day01.Tests
{
    [TestFixture]
    public class When_calculating_fuel_for_a_module
    {
        [TestCase(12, ExpectedResult = 2)]
        [TestCase(14, ExpectedResult = 2)]
        [TestCase(1969, ExpectedResult = 654)]
        [TestCase(100756, ExpectedResult = 33583)]
        public decimal Then_the_correct_fuel_amount_is_returned(int mass)
        {
            var sut = new FuelCounterUpper();
            return sut.CalculateFuel(mass);
        }
    }

    [TestFixture]
    public class When_calculating_fuel_for_multiple_modules
    {
        [Test]
        public void Then_the_correct_total_is_returned()
        {
            var modules = new int[] { 12, 14, 1969, 100756 };
            var expected = new[] { 2, 2, 654, 33583 }.Sum();

            var sut = new FuelCounterUpper();
            var result = sut.CalculateFuel(modules);
            Assert.That(result, Is.EqualTo(expected));
        }
    }

    public class When_calculating_extra_fuel_for_a_module
    {
        [TestCase(2, ExpectedResult = 0)]
        [TestCase(654, ExpectedResult = 312)]
        [TestCase(33583, ExpectedResult = 16763)]
        public decimal Then_the_correct_fuel_amount_is_returned(int mass)
        {
            var sut = new FuelCounterUpper();
            return sut.CalculateExtraFuel(mass);
        }
    }

    public class When_calculating_total_fuel_for_a_module
    {
        [TestCase(12, ExpectedResult = 2)]
        [TestCase(14, ExpectedResult = 2)]
        [TestCase(1969, ExpectedResult = 966)]
        [TestCase(100756, ExpectedResult = 50346)]
        public decimal Then_the_correct_fuel_amount_is_returned(int mass)
        {
            var sut = new FuelCounterUpper();
            return sut.CalculateTotalFuelForModule(mass);
        }
    }

    public class When_calculating_all_modules_fuel
    {
        [Test]
        public void Then_we_get_the_total_fuel()
        {
            var testFilePath = "..//..//..//TestData//input.txt";

            var expected = 3394032;

            var sut = new FuelCounterUpper();
            var result = sut.CalculateFuelFromFile(testFilePath);
            Assert.That(result, Is.EqualTo(expected));
        }
    }

    public class When_calculating_all_modules_fuel_including_fuel_mass
    {
        [Test]
        public void Then_we_get_the_total_fuel()
        {
            var testFilePath = "..//..//..//TestData//input.txt";

            var expected = 5088176;

            var sut = new FuelCounterUpper();
            var result = sut.CalculateTotalFuelFromFile(testFilePath);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}