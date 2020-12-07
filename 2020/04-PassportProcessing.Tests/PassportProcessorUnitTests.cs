using Moq;
using NUnit.Framework;
using PassportProcessing.FieldValidators;
using Tools;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable StringLiteralTypo

namespace PassportProcessing.Tests.PassportProcessorUnitTests
{
    [TestFixture]
    public class When_processing_passports
    {
        private PassportProcessor _passportProcessor;

        [SetUp]
        public void SetUp()
        {
            const string testData = @"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in";

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInput(It.IsAny<string>())).Returns(testData);

            _passportProcessor = new PassportProcessor(mockPuzzleInput.Object, new Mock<IFieldValidationService>().Object);
        }


        [Test]
        public void Then_the_correct_number_are_counted_valid()
        {
            Assert.That(_passportProcessor.ValidPassports, Is.EqualTo(2));
        }
    }
}