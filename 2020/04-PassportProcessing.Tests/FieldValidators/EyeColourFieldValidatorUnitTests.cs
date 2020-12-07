using NUnit.Framework;
using PassportProcessing.FieldValidators;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace PassportProcessing.Tests.FieldValidators.EyeColourValidatorUnitTests
{
    [TestFixture]
    public class When_validating_field
    {
        [TestCase("brn", true)]
        [TestCase("wat", false)]
        public void Then_the_result_is_correct(string value, bool expectedResult)
        {
            var validator = new EyeColourValidator();
            Assert.That(validator.IsValid(value), Is.EqualTo(expectedResult));
        }
    }
}