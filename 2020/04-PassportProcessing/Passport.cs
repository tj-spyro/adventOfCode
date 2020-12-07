using System;
using System.Collections.Generic;
using System.Linq;
using PassportProcessing.FieldValidators;

namespace PassportProcessing
{
    public class Passport
    {
        private static readonly IEnumerable<string> MandatoryFields = new[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

        private readonly IDictionary<string, string> _fields;

        private Passport(IDictionary<string, string> fields)
        {
            _fields = fields;
        }

        public static Passport CreatePassport(string input)
        {
            var kVPairs = input.Replace('\n', ' ').Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var fields = kVPairs.Select(k => k.Split(':'))
                .ToDictionary(a => a[0], a => a[1]);

            return new Passport(fields);
        }

        public int FieldCount => _fields.Count;

        public bool ContainsMandatoryFields => MandatoryFields.All(_fields.ContainsKey);

        public bool ValidateDataIntegrity(IFieldValidationService fieldValidationService)
        {
            return ContainsMandatoryFields && fieldValidationService.Validate(_fields);
        }
    }
}