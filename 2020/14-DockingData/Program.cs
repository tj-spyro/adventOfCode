using System;
using Tools;
using Unity;

namespace DockingData
{
    class Program
    {
        static void Main()
        {
            var container = BuildUnityContainer();

            var memory = container.Resolve<IMemory>();
            memory.Initialise();
            Console.WriteLine($"Part 1: {memory.Sum()}");

            var memory2 = container.Resolve<IMemory>(nameof(Memory2));
            memory2.Initialise();
            Console.WriteLine($"Part 2: {memory2.Sum()}");
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IBitMasker, BitMasker>();
            container.RegisterType<IMemory, Memory>();
            container.RegisterType<IMemory, Memory2>(nameof(Memory2));
            return container;
        }
    }
}
