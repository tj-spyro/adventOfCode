using System;
using Tools;
using Unity;

namespace AdapterArray
{
    class Program
    {
        static void Main()
        {
            var container = BuildUnityContainer();

            var processor = container.Resolve<IAdapterProcessor>();

            Console.WriteLine($"Part 1: {processor.Solve1()}");
            Console.WriteLine($"Part 2: {processor.Solve2()}");
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IAdapterProcessor, AdapterProcessor>();
            return container;
        }
    }
}
