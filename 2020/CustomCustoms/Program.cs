using System;
using Tools;
using Unity;

namespace CustomCustoms
{
    class Program
    {
        static void Main()
        {
            var container = BuildUnityContainer();

            var repository = container.Resolve<IDeclarationFormRepository>();

            Console.WriteLine($"Part 1: {repository.SumOfYesAnswers}");
            Console.WriteLine($"Part 2: {repository.SumOfIntersectYesAnswers}");
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IDeclarationFormRepository, DeclarationFormRepository>();
            return container;
        }
    }
}
