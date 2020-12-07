using System.Collections.Generic;

namespace PassportProcessing.FieldValidators
{
    public interface IFieldValidationService
    {
        IFieldValidator BirthYear { get; }
        IFieldValidator IssueYear { get; }
        IFieldValidator ExpirationYear { get; }
        IFieldValidator Height { get; }
        IFieldValidator HairColour { get; }
        IFieldValidator EyeColour { get; }
        IFieldValidator PassportId { get; }
        bool Validate(IDictionary<string, string> fields);
    }
}