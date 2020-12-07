using CustomCustoms.Forms;
using NUnit.Framework;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable StringLiteralTypo

namespace CustomCustoms.Tests.Forms.IndividualResponseUnitTests
{
    [TestFixture]
    public class When_creating_from_string
    {
        [TestCase("abcx", 4)]
        [TestCase("abcy", 4)]
        [TestCase("abcz", 4)]
        [TestCase("abc", 3)]
        [TestCase("ab", 2)]
        [TestCase("a", 1)]
        public void Then_correct_number_of_answered_yes_are_found(string input, int expectedCount)
        {
            Assert.That(new IndividualResponse(input).AnsweredYes.Length, Is.EqualTo(expectedCount));
        }
    }
}