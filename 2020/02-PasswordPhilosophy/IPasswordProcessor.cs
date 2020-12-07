using PasswordValidator.Policies;

namespace PasswordValidator
{
    public interface IPasswordProcessor
    {
        int ValidPasswordsCount(PolicyType policyType);
    }
}