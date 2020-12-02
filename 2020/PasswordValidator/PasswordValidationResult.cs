namespace PasswordValidator
{
    public class PasswordValidationResult
    {
        public PasswordValidationResult(string input)
        {
            var parts = input.Split(':');

            Policy = PasswordPolicy.CreatePasswordPolicy(parts[0].Trim());
            Password = parts[1].Trim();
        }

        public PasswordPolicy Policy;
        public string Password;
        public bool Result => Policy.ValidatePassword(Password);
    }
}