using System;
using System.Collections.Generic;
using System.Linq;
using PasswordValidator.Policies;

namespace PasswordValidator
{
    public class PasswordProcessor
    {
        private readonly IEnumerable<string> _passwordData;
        private readonly PolicyType _policyType;

        private IEnumerable<PasswordValidationResult> _results;
        private IEnumerable<PasswordValidationResult> Results => _results ??= ProcessPasswords();

        public PasswordProcessor(IEnumerable<string> passwordData, PolicyType policyType)
        {
            _passwordData = passwordData;
            _policyType = policyType;
        }

        public int ValidPasswordsCount()
        {
            return Results.Count(r => r.Result);
        }

        private IEnumerable<PasswordValidationResult> ProcessPasswords()
        {
            return _passwordData.Select(pd =>
            {
                var parts = pd.Split(':');
                return new PasswordValidationResult(parts[1].Trim(), GetPasswordPolicy(parts[0].Trim()));
            });
        }

        private IPasswordPolicy GetPasswordPolicy(string policyString)
        {
            return _policyType switch
            {
                PolicyType.Occurrence => OccurrencePasswordPolicy.CreatePasswordPolicy(policyString),
                PolicyType.Positional => PositionalPasswordPolicy.CreatePasswordPolicy(policyString),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}