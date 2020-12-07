using System.Collections.Generic;
using System.Linq;
using PasswordValidator.Policies;
using Tools;

namespace PasswordValidator
{
    public class PasswordProcessor : IPasswordProcessor
    {
        private readonly IPuzzleInput _puzzleInput;
        private const string PuzzleInputUrl = "https://adventofcode.com/2020/day/2/input";
        private readonly IPasswordPolicyFactory _passwordPolicyFactory;

        private IEnumerable<string> _passwordData;
        private IEnumerable<string> PasswordData => _passwordData ??= _puzzleInput.GetPuzzleInputAsArray(PuzzleInputUrl);

        private PolicyType _policyType;

        private IEnumerable<PasswordValidationResult> _results;
        private IEnumerable<PasswordValidationResult> Results => _results ??= ProcessPasswords();

        public PasswordProcessor(IPuzzleInput puzzleInput, IPasswordPolicyFactory passwordPolicyFactory)
        {
            _puzzleInput = puzzleInput;
            _passwordPolicyFactory = passwordPolicyFactory;
        }

        public int ValidPasswordsCount(PolicyType policyType)
        {
            _policyType = policyType;
            return Results.Count(r => r.Result);
        }

        private IEnumerable<PasswordValidationResult> ProcessPasswords()
        {
            return PasswordData.Select(pd =>
            {
                var parts = pd.Split(':');
                return new PasswordValidationResult(parts[1].Trim(),
                    _passwordPolicyFactory.GetPasswordPolicy(_policyType, parts[0].Trim()));
            });
        }
    }
}