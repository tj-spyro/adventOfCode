using NUnit.Framework;

namespace SantasSpacecraft.Tests.Day04
{
    [TestFixture]
    public class When_checking_for_the_password_rules
    {
        [TestCase(12345, false)]
        [TestCase(123456, true)]
        [TestCase(1234567, false)]
        public void Then_checking_for_password_is_6_digits_returns_correct(int input, bool expected)
        {
            var result = PasswordFinder.PasswordFinder.IsSixDigits(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(22, true)]
        [TestCase(122345, true)]
        [TestCase(123456, false)]
        public void Then_checking_for_adjacent_matching_digits_returns_correct(int input, bool expected)
        {
            var result = PasswordFinder.PasswordFinder.HasAdjacentMatchingDigits(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(111123, true)]
        [TestCase(135679, true)]
        [TestCase(123426, false)]
        public void Then_checking_for_digits_never_decreasing_returns_correct(int input, bool expected)
        {
            var result = PasswordFinder.PasswordFinder.DigitsIncrease(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(111111, true)]
        [TestCase(223450, false)]
        [TestCase(123789, false)]
        public void The_checking_all_rules_returns_correct(int input, bool expected)
        {
            var result = PasswordFinder.PasswordFinder.PassesAllRules(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class SolveProblem
    {
        [TestCase(367479, 893698, 495)]
        public void Get_answer_part1(int lowerLimit, int upperLimit, int expected)
        {
            var result = PasswordFinder.PasswordFinder.GetNumberOfPotentialValidPasswords(lowerLimit, upperLimit);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}