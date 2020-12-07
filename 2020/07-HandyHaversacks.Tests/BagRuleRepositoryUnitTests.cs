using Moq;
using NUnit.Framework;
using Tools;

namespace HandyHaversacks.Tests.BagRuleRepositoryUnitTests
{
    [TestFixture]
    public class When_getting_sample_answer1
    {
        private BagRuleRepository _repository;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.", "dotted black bags contain no other bags."
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _repository = new BagRuleRepository(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_the_answer_is_correct()
        {
            Assert.That(_repository.Answer1("shiny gold"), Is.EqualTo(4));
        }
    }

    [TestFixture]
    public class When_getting_sample_answer2_example1
    {
        private BagRuleRepository _repository;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.", "dotted black bags contain no other bags."
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _repository = new BagRuleRepository(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_the_answer_is_correct()
        {
            Assert.That(_repository.Answer2("shiny gold"), Is.EqualTo(32));
        }
    }

    [TestFixture]
    public class When_getting_sample_answer2_example2
    {
        private BagRuleRepository _repository;

        [SetUp]
        public void Setup()
        {
            var testData = new[]
            {
                "shiny gold bags contain 2 dark red bags.", "dark red bags contain 2 dark orange bags.",
                "dark orange bags contain 2 dark yellow bags.", "dark yellow bags contain 2 dark green bags.",
                "dark green bags contain 2 dark blue bags.", "dark blue bags contain 2 dark violet bags.",
                "dark violet bags contain no other bags."
            };

            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(testData);

            _repository = new BagRuleRepository(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_the_answer_is_correct()
        {
            Assert.That(_repository.Answer2("shiny gold"), Is.EqualTo(126));
        }
    }
}