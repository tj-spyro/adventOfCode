using System;
// ReSharper disable ClassNeverInstantiated.Global

namespace PasswordValidator.Policies
{
    public class PasswordPolicyFactory : IPasswordPolicyFactory
    {
        public IPasswordPolicy GetPasswordPolicy(PolicyType type, string policyString)
        {
            return type switch
            {
                PolicyType.Occurrence => OccurrencePasswordPolicy.CreatePasswordPolicy(policyString),
                PolicyType.Positional => PositionalPasswordPolicy.CreatePasswordPolicy(policyString),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}