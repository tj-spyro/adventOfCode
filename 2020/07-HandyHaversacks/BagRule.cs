using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HandyHaversacks
{
    public class BagRule
    {
        private static Regex ColourRegex => new Regex(@"^(?'colour'[a-zA-Z ]{1,}) bags contain");
        private static Regex ContainsRegex => new Regex(@"(?'qty'[\d]{1,}) (?'colour'[a-zA-Z ]{1,}) bag");

        public readonly string Colour;
        public readonly IList<(string colour, int quantity)> Holds;

        public BagRule(string input)
        {
            var matchColour = ColourRegex.Match(input);
            Colour = matchColour.Groups["colour"].Value;
            var matchContains = ContainsRegex.Matches(input);
            Holds = matchContains.Select(m => (m.Groups["colour"].Value, int.Parse(m.Groups["qty"].Value))).ToList();
        }
    }
}