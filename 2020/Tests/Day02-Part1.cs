using System.IO;
using NUnit.Framework;
using PasswordValidator;

namespace Tests.Day02Part1
{
    [TestFixture]
    public class When_validating_a_password
    {
        [TestCase("1-3 a", "abcde", true)]
        [TestCase("1-3 b", "cdefg", false)]
        [TestCase("2-9 c", "ccccccccc", true)]
        public void Then_the_validation_response_is_correct(string policy, string password, bool expectedResult)
        {
            var passwordPolicy = PasswordPolicy.CreatePasswordPolicy(policy);

            Assert.That(passwordPolicy.ValidatePassword(password), Is.EqualTo(expectedResult));
        }
    }

    [TestFixture]
    public class When_counting_the_valid_example_passwords
    {
        private PasswordProcessor _processor;

        [OneTimeSetUp]
        public void SetUp()
        {
            var testData = new[] {"1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc"};

            _processor = new PasswordProcessor(testData);
        }
        
        [Test]
        public void Then_the_correct_result_is_returned()
        {
            Assert.That(_processor.ValidPasswordsCount(), Is.EqualTo(2));
        }
    }

    [TestFixture]
    public class When_counting_the_valid_passwords
    {
        private PasswordProcessor _processor;

        [OneTimeSetUp]
        public void SetUp()
        {
            var data = File.ReadAllLines("Data/Day02.txt");

            _processor = new PasswordProcessor(data);
        }

        [Test]
        public void Then_the_correct_result_is_returned()
        {
            Assert.That(_processor.ValidPasswordsCount(), Is.EqualTo(458));
        }
    }
}