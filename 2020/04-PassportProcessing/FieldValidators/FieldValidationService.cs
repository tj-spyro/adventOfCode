using System.Collections.Generic;
using System.Linq;
using Unity;

namespace PassportProcessing.FieldValidators
{
    public class FieldValidationService : IFieldValidationService
    {
        [Dependency(nameof(BirthYear))]
        public IFieldValidator BirthYear { get; set; }

        [Dependency(nameof(IssueYear))]
        public IFieldValidator IssueYear { get; set; }

        [Dependency(nameof(ExpirationYear))]
        public IFieldValidator ExpirationYear { get; set; }

        [Dependency(nameof(Height))]
        public IFieldValidator Height { get; set; }

        [Dependency(nameof(HairColour))]
        public IFieldValidator HairColour { get; set; }

        [Dependency(nameof(EyeColour))]
        public IFieldValidator EyeColour { get; set; }

        [Dependency(nameof(PassportId))]
        public IFieldValidator PassportId { get; set; }

        public bool Validate(IDictionary<string, string> fields)
        {
            return fields.All(ValidateField);
        }

        private bool ValidateField(KeyValuePair<string, string> kvp)
        {
            var (key, value) = kvp;
            return key switch
            {
                "byr" => BirthYear.IsValid(value),
                "iyr" => IssueYear.IsValid(value),
                "eyr" => ExpirationYear.IsValid(value),
                "hgt" => Height.IsValid(value),
                "hcl" => HairColour.IsValid(value),
                "ecl" => EyeColour.IsValid(value),
                "pid" => PassportId.IsValid(value),
                "cid" => true,
                _ => false
            };
        }
    }
}