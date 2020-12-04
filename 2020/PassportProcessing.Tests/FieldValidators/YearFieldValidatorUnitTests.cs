using NUnit.Framework;
using PassportProcessing.FieldValidators;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable StringLiteralTypo

namespace PassportProcessing.Tests.FieldValidators.YearFieldValidatorUnitTests
{
    [TestFixture]
    public class When_validating_field
    {
        [TestCase("1919", false)]
        [TestCase("1920", true)]
        [TestCase("1989", true)]
        [TestCase("2002", true)]
        [TestCase("2003", false)]
        [TestCase("20", false)]
        [TestCase("aaaa", false)]
        public void Then_the_result_is_correct(string value, bool expectedResult)
        {
            var validator = new YearFieldValidator(1920, 2002);
            Assert.That(validator.IsValid(value), Is.EqualTo(expectedResult));
        }
    }
}