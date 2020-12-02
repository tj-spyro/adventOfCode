using PasswordValidator.Policies;

namespace PasswordValidator
{
    public class PasswordValidationResult
    {
        public PasswordValidationResult(string password, IPasswordPolicy policy)
        {
            Policy = policy;
            Password = password;
        }

        public IPasswordPolicy Policy;
        public string Password;
        public bool Result => Policy.ValidatePassword(Password);
    }
}