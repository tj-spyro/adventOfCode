using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordValidator.Policies
{
    public class PositionalPasswordPolicy : IPasswordPolicy
    {
        private readonly int _firstPosition;
        private readonly int _secondPosition;
        private readonly string _letter;

        public PolicyType Type => PolicyType.Positional;

        private PositionalPasswordPolicy(int firstPosition, int secondPosition, string letter)
        {
            _firstPosition = firstPosition;
            _secondPosition = secondPosition;
            _letter = letter;
        }

        public static IPasswordPolicy CreatePasswordPolicy(string policyString)
        {
            var splitOnSpace = policyString.Split(' ');

            var splitOnHyphen = splitOnSpace[0].Split('-');

            var letter = splitOnSpace[1];

            var firstValueStr = splitOnHyphen[0];
            var secondValueStr = splitOnHyphen[1];

            if (!int.TryParse(firstValueStr, out var firstPosition))
            {
                throw new ArgumentException($"The first value of '{firstValueStr}' does not parse to an int.");
            }
            if (!int.TryParse(secondValueStr, out var secondPosition))
            {
                throw new ArgumentException($"The second value of '{secondValueStr}' does not parse to an int.");
            }
            if (string.IsNullOrEmpty(letter) || letter.Length != 1)
            {
                throw new ArgumentException($"The letter value of '{letter}' is invalid.");
            }
            if (firstPosition < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(firstPosition), firstPosition, "Must be greater than zero.");
            }
            if (secondPosition < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(secondPosition), secondPosition, "Must be greater than zero.");
            }

            return new PositionalPasswordPolicy(firstPosition, secondPosition, letter);
        }

        public bool ValidatePassword(string password)
        {
            var matches = Regex.Matches(password, _letter);

            var firstPositionMatches = matches.Count(m => m.Index.Equals(_firstPosition - 1));
            var secondPositionMatches = matches.Count(m => m.Index.Equals(_secondPosition - 1));

            return firstPositionMatches + secondPositionMatches == 1;
        }
    }
}
