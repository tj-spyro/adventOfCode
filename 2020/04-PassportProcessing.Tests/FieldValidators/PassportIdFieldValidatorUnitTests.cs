using NUnit.Framework;
using PassportProcessing.FieldValidators;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace PassportProcessing.Tests.FieldValidators.PassportIdFieldValidatorUnitTests
{
    [TestFixture]
    public class When_validating_field
    {
        [TestCase("000000001", true)]
        [TestCase("0123456789", false)]
        public void Then_the_result_is_correct(string value, bool expectedResult)
        {
            var validator = new PassportIdValidator();
            Assert.That(validator.IsValid(value), Is.EqualTo(expectedResult));
        }
    }
}