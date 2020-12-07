using CustomCustoms.Forms;
using NUnit.Framework;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable StringLiteralTypo

namespace CustomCustoms.Tests.Forms.DeclarationFormUnitTests
{
    [TestFixture("abc", 1, 3, 3)]
    [TestFixture("a\nb\nc", 3, 3, 0)]
    [TestFixture("ab\r\nac", 2, 3, 1)]
    [TestFixture("a\na\na\na", 4, 1, 1)]
    [TestFixture("b", 1, 1, 1)]
    public class When_parsing_a_group_string_input
    {
        private readonly string _input;
        private readonly int _partySize;
        private readonly int _yesAnswers;
        private readonly int _intersectYesAnswers;

        private DeclarationForm _declarationForm;

        public When_parsing_a_group_string_input(string input, int partySize, int yesAnswers, int intersectYesAnswers)
        {
            _input = input;
            _partySize = partySize;
            _yesAnswers = yesAnswers;
            _intersectYesAnswers = intersectYesAnswers;
        }

        [SetUp]
        public void SetUp()
        {
            _declarationForm = new DeclarationForm(_input);
        }

        [Test]
        public void Then_the_party_size_is_correct()
        {
            Assert.That(_declarationForm.PartySize, Is.EqualTo(_partySize));
        }

        [Test]
        public void Then_the_yes_answers_is_correct()
        {
            Assert.That(_declarationForm.DistinctYesAnswers, Is.EqualTo(_yesAnswers));
        }

        [Test]
        public void Then_the_yes_intersect_answers_is_correct()
        {
            Assert.That(_declarationForm.IntersectionOfAnswers, Is.EqualTo(_intersectYesAnswers));
        }
    }
}