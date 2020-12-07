using NUnit.Framework;
using PassportProcessing.FieldValidators;
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace PassportProcessing.Tests.FieldValidators.HeightFieldValidatorUnitTests
{
    [TestFixture]
    public class When_validating_field
    {
        [TestCase("60in", true)]
        [TestCase("190cm", true)]
        [TestCase("190in", false)]
        [TestCase("190", false)]
        public void Then_the_result_is_correct(string value, bool expectedResult)
        {
            var validator = new HeightFieldValidator();
            Assert.That(validator.IsValid(value), Is.EqualTo(expectedResult));
        }
    }
}