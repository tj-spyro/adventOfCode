using System;
using Tools;
using Unity;


namespace HandyHaversacks
{
    class Program
    {
        static void Main()
        {
            var container = BuildUnityContainer();

            var repository = container.Resolve<IBagRuleRepository>();

            Console.WriteLine($"Part 1: {repository.Answer1("shiny gold")}");
            Console.WriteLine($"Part 2: {repository.Answer2("shiny gold")}");
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IBagRuleRepository, BagRuleRepository>();
            return container;
        }
    }
}
