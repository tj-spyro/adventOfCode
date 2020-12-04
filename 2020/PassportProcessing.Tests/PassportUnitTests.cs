using NUnit.Framework;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable StringLiteralTypo

namespace PassportProcessing.Tests.PassportUnitTests
{
    [TestFixture("ecl:gry pid:860033327 eyr:2020 hcl:#fffffd\nbyr:1937 iyr:2017 cid:147 hgt:183cm", 8, true)]
    [TestFixture("iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884\nhcl:#cfa07d byr:1929", 7, false)]
    [TestFixture("hcl:#ae17e1 iyr:2013\neyr:2024\necl:brn pid:760753108 byr:1931\nhgt:179cm", 7, true)]
    [TestFixture("hcl:#cfa07d eyr:2025 pid:166559648\niyr:2011 ecl:brn hgt:59in", 6, false)]
    public class When_parsing_a_passport
    {
        private readonly string _input;
        private readonly int _fieldCount;
        private readonly bool _containsMandatoryFields;

        private Passport _passport;

        public When_parsing_a_passport(string input, int fieldCount, bool containsMandatoryFields)
        {
            _input = input;
            _fieldCount = fieldCount;
            _containsMandatoryFields = containsMandatoryFields;
        }
        
        [SetUp]
        public void SetUp()
        {
            _passport = Passport.CreatePassport(_input);
        }

        [Test]
        public void Then_the_correct_number_of_fields_are_found()
        {
            Assert.That(_passport.FieldCount , Is.EqualTo(_fieldCount));
        }

        [Test]
        public void Then_the_passport_has_the_correct_mandatory_fields_flag()
        {
            Assert.That(_passport.ContainsMandatoryFields , Is.EqualTo(_containsMandatoryFields));
        }
    }
}