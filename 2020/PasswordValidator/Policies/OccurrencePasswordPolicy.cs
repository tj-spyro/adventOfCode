using System;
using System.Text.RegularExpressions;

namespace PasswordValidator.Policies
{
    public class OccurrencePasswordPolicy : IPasswordPolicy
    {
        private readonly int _minimumOccurrences;
        private readonly int _maximumOccurrences;
        private readonly string _letter;

        public PolicyType Type => PolicyType.Occurrence;

        private OccurrencePasswordPolicy(int minimumOccurrences, int maximumOccurrences, string letter)
        {
            _minimumOccurrences = minimumOccurrences;
            _maximumOccurrences = maximumOccurrences;
            _letter = letter;
        }

        public static IPasswordPolicy CreatePasswordPolicy(string policyString)
        {
            var splitOnSpace = policyString.Split(' ');

            var splitOnHyphen = splitOnSpace[0].Split('-');

            var letter = splitOnSpace[1];

            var minValueStr = splitOnHyphen[0];
            var maxValueStr = splitOnHyphen[1];

            if (!int.TryParse(minValueStr, out var parsedMinValue))
            {
                throw new ArgumentException($"The min value of '{minValueStr}' does not parse to an int.");
            }
            if (!int.TryParse(maxValueStr, out var parsedMaxValue))
            {
                throw new ArgumentException($"The max value of '{maxValueStr}' does not parse to an int.");
            }
            if (string.IsNullOrEmpty(letter) || letter.Length != 1)
            {
                throw new ArgumentException($"The letter value of '{letter}' is invalid.");
            }
            if (parsedMinValue < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(parsedMinValue), parsedMinValue, "Must be greater than zero.");
            }
            if (parsedMinValue > parsedMaxValue)
            {
                throw new ArgumentException("Min value cannot be greater than max value.");
            }

            return new OccurrencePasswordPolicy(parsedMinValue, parsedMaxValue, letter);
        }

        public bool ValidatePassword(string password)
        {
            var matches = Regex.Matches(password, _letter);

            return matches.Count >= _minimumOccurrences && matches.Count <= _maximumOccurrences;
        }
    }
}
