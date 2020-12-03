using PasswordValidator.Policies;
using System;
using Tools;
using Unity;

namespace PasswordValidator
{
    class Program
    {
        static void Main()
        {
            var container = BuildUnityContainer();

            var passwordProcessor = container.Resolve<IPasswordProcessor>();

            Console.WriteLine($"Part 1: {passwordProcessor.ValidPasswordsCount(PolicyType.Occurrence)}");
            Console.WriteLine($"Part 2: {passwordProcessor.ValidPasswordsCount(PolicyType.Positional)}");
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IPasswordPolicyFactory, PasswordPolicyFactory>();
            container.RegisterType<IPasswordProcessor, PasswordProcessor>();
            return container;
        }
    }
}