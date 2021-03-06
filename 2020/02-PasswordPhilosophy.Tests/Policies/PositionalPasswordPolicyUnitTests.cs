using NUnit.Framework;
using PasswordValidator.Policies;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable StringLiteralTypo

namespace PasswordValidator.Tests.Policies.PositionalPasswordPolicyUnitTests
{
    [TestFixture]
    public class When_validating_a_password
    {
        [TestCase("1-3 a", "abcde", true)]
        [TestCase("1-3 b", "cdefg", false)]
        [TestCase("2-9 c", "ccccccccc", false)]
        public void Then_the_validation_response_is_correct(string policy, string password, bool expectedResult)
        {
            var passwordPolicy = PositionalPasswordPolicy.CreatePasswordPolicy(policy);

            Assert.That(passwordPolicy.ValidatePassword(password), Is.EqualTo(expectedResult));
        }
    }
}