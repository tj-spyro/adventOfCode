using System;
using Tools;
using Unity;

namespace TobogganTrajectory
{
    class Program
    {
        static void Main()
        {
            var container = BuildUnityContainer();

            var treeCounter = container.Resolve<ITreeCounter>();

            Console.WriteLine($"Part 1: {treeCounter.Run(3,1)}");

            long product = 1;
            product *= treeCounter.Run(1, 1);
            product *= treeCounter.Run(3, 1);
            product *= treeCounter.Run(5, 1);
            product *= treeCounter.Run(7, 1);
            product *= treeCounter.Run(1, 2);

            Console.WriteLine($"Part 2: {product}");
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IMap, Map>();
            container.RegisterType<ITreeCounter, TreeCounter>();
            return container;
        }
    }
}
