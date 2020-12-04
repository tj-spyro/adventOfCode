using System.Text.RegularExpressions;

namespace PassportProcessing.FieldValidators
{
    public class PassportIdValidator : IFieldValidator
    {
        public bool IsValid(string value)
        {
            return Regex.IsMatch(value, @"^[0-9]{9}$");
        }
    }
}