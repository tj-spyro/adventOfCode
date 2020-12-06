using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable StringLiteralTypo

namespace CustomCustoms.Tests.DeclarationFormRepositoryUnitTests
{
    [TestFixture]
    public class When_processing_the_raw_data
    {
        private DeclarationFormRepository _declarationFormRepository;

        [SetUp]
        public void Setup()
        {
            var testData = new [] { "abc", "a\nb\nc", "ab\nac", "a\na\na\na", "b"};

        var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputSplitByBlankLines(It.IsAny<string>())).Returns(testData);

            _declarationFormRepository = new DeclarationFormRepository(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_the_correct_number_of_forms_are_found()
        {
            Assert.That(_declarationFormRepository.Forms.Count() , Is.EqualTo(5));
        }

        [Test]
        public void Then_the_correct_sum_of_yes_answers_is_found()
        {
            Assert.That(_declarationFormRepository.SumOfYesAnswers, Is.EqualTo(11));
        }

        [Test]
        public void Then_the_correct_sum_of_yes_intersect_answers_is_found()
        {
            Assert.That(_declarationFormRepository.SumOfIntersectYesAnswers, Is.EqualTo(6));
        }
    }
}