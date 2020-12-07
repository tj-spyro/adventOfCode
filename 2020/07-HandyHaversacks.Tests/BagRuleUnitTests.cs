using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable StringLiteralTypo

namespace HandyHaversacks.Tests.BagRuleUnitTests
{
    [TestFixture("light red bags contain 1 bright white bag, 2 muted yellow bags.", "light red", "bright white|muted yellow")]
    [TestFixture("dark orange bags contain 3 bright white bags, 4 muted yellow bags.", "dark orange", "bright white|muted yellow")]
    [TestFixture("bright white bags contain 1 shiny gold bag.", "bright white", "shiny gold")]
    [TestFixture("muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.", "muted yellow", "shiny gold|faded blue")]
    [TestFixture("shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.", "shiny gold", "dark olive|vibrant plum")]
    [TestFixture("dark olive bags contain 3 faded blue bags, 4 dotted black bags.", "dark olive", "faded blue|dotted black")]
    [TestFixture("vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.", "vibrant plum", "faded blue|dotted black")]
    [TestFixture("faded blue bags contain no other bags.", "faded blue", "")]
    [TestFixture("dotted black bags contain no other bags.", "dotted black", "")]
    public class When_parsing_an_input
    {
        private readonly string _input;
        private readonly string _colour;
        private readonly IList<string> _containsColours;
        private BagRule _bagRule;

        public When_parsing_an_input(string input, string colour, string containsColours)
        {
            _input = input;
            _colour = colour;
            _containsColours = containsColours.Split('|', StringSplitOptions.RemoveEmptyEntries);
        }

        [SetUp]
        public void Setup()
        {
            _bagRule = new BagRule(_input);
        }

        [Test]
        public void Then_the_colour_is_correct()
        {
            Assert.That(_bagRule.Colour, Is.EqualTo(_colour));
        }

        [Test]
        public void Then_the_holds_is_correct()
        {
            Assert.That(
                _bagRule.Holds.Select(h => h.colour).All(_containsColours.Contains) &&
                _bagRule.Holds.Count == _containsColours.Count,
                Is.True);
        }
    }
}