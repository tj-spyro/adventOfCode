using System;
using Tools;
using Unity;

// ReSharper disable CheckNamespace

namespace ShuttleSearch
{
    class Program
    {
        static void Main()
        {
            var container = BuildUnityContainer();

            var processor = container.Resolve<ITimeTable>();

            Console.WriteLine($"Part 1: {processor.Solve1()}");
            Console.WriteLine($"Part 2: {processor.Solve2()}");
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<ITimeTable, TimeTable>();
            return container;
        }
    }
}
