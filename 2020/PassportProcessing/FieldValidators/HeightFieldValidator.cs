using System;

namespace PassportProcessing.FieldValidators
{
    public class HeightFieldValidator : IFieldValidator
    {
        private const int CmLowerBounds = 150;
        private const int CmUpperBounds = 193;
        private const int InLowerBounds = 59;
        private const int InUpperBounds = 76;

        public bool IsValid(string value)
        {
            return value != null
                && (!int.TryParse(value, out _)
                && value[^2..].ToLower() == "cm"
                    ? MetricValidation(value)
                    : value[^2..].ToLower() == "in"
                      && ImperialValidation(value));

        }

        private static bool MetricValidation(string value)
        {
            var number = int.Parse(value.Replace("cm", string.Empty, StringComparison.InvariantCultureIgnoreCase));

            return number >= CmLowerBounds && number <= CmUpperBounds;
        }

        private static bool ImperialValidation(string value)
        {
            var number = int.Parse(value.Replace("in", string.Empty, StringComparison.InvariantCultureIgnoreCase));

            return number >= InLowerBounds && number <= InUpperBounds;
        }
    }
}