namespace PasswordValidator.Policies
{
    public interface IPasswordPolicy
    {
        PolicyType Type { get; }
        bool ValidatePassword(string password);
    }
}