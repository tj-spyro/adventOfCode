using System.Text.RegularExpressions;

namespace PassportProcessing.FieldValidators
{
    public class HairColourValidator : IFieldValidator
    {
        public bool IsValid(string value)
        {
            return Regex.IsMatch(value, @"^#[0-9a-fA-F]{6}");
        }
    }
}