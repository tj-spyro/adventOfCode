using System;
using System.Collections.Generic;
using System.Linq;

namespace PassportProcessing.FieldValidators
{
    public class EyeColourValidator : IFieldValidator
    {
        private readonly IEnumerable<string> _validColours = new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
        
        public bool IsValid(string value)
        {
            return value.Length == 3 &&
                   _validColours.Any(c => value.Equals(c, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}