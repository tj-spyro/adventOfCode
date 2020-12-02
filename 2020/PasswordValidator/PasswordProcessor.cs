using System.Collections.Generic;
using System.Linq;

namespace PasswordValidator
{
    public class PasswordProcessor
    {
        private readonly IEnumerable<string> _passwordData;

        private IEnumerable<PasswordValidationResult> _results;
        private IEnumerable<PasswordValidationResult> Results => _results ??= ProcessPasswords();

        public PasswordProcessor(IEnumerable<string> passwordData)
        {
            _passwordData = passwordData;
        }

        public int ValidPasswordsCount()
        {
            return Results.Count(r => r.Result);
        }

        private IEnumerable<PasswordValidationResult> ProcessPasswords()
        {
            return _passwordData.Select(pd => new PasswordValidationResult(pd));
        }
    }
}