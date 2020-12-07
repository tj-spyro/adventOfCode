namespace PasswordValidator.Policies
{
    public interface IPasswordPolicyFactory
    {
        IPasswordPolicy GetPasswordPolicy(PolicyType type, string policyString);
    }
}