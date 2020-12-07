using System.Collections.Generic;
using System.Linq;
using Tools;

namespace HandyHaversacks
{
    public class BagRuleRepository : IBagRuleRepository
    {
        private readonly IPuzzleInput _puzzleInput;
        private const string PuzzleInputUrl = "https://adventofcode.com/2020/day/7/input";

        private IEnumerable<string> _rawData;
        private IEnumerable<string> RawData => _rawData ??= _puzzleInput.GetPuzzleInputAsArray(PuzzleInputUrl);

        public BagRuleRepository(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }

        private IEnumerable<BagRule> _rules;
        private IEnumerable<BagRule> Rules => _rules ??= RawData.Select(d => new BagRule(d));

        public int Answer1(string bagColour)
        {
            var bags = Rules.Where(r => r.Holds.Any(h => h.colour.Equals(bagColour))).Select(b => b.Colour).ToList();
            var total = bags;
            while (bags.Any())
            {
                bags = bags.SelectMany(b => Rules.Where(r => r.Holds.Any(h => h.colour.Equals(b))).Select(br => br.Colour))
                    .ToList();

                total = total.Concat(bags).ToList();
            }

            return total.Distinct().Count();
        }

        public int Answer2(string bagColour) => TotalBagCount(bagColour) - 1;

        private BagRule GetBagRule(string bagColour) => Rules.Single(r => r.Colour.Equals(bagColour));

        private int TotalBagCount(string color)
            => 1 + GetBagRule(color).Holds.Sum(x => x.quantity * TotalBagCount(x.colour));
    }
}