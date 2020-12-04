using NUnit.Framework;
using PassportProcessing.FieldValidators;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace PassportProcessing.Tests.FieldValidators.HairColourValidatorUnitTests
{
    [TestFixture]
    public class When_validating_field
    {
        [TestCase("#123abc", true)]
        [TestCase("#123abz", false)]
        [TestCase("123abc", false)]
        public void Then_the_result_is_correct(string value, bool expectedResult)
        {
            var validator = new HairColourValidator();
            Assert.That(validator.IsValid(value), Is.EqualTo(expectedResult));
        }
    }
}