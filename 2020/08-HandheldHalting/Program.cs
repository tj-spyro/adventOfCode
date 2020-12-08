using System;
using Tools;
using Unity;

// ReSharper disable CheckNamespace

namespace HandheldHalting
{
    class Program
    {
        static void Main()
        {
            var container = BuildUnityContainer();

            var repository = container.Resolve<IBootCode>();

            Console.WriteLine($"Part 1: {repository.Answer1()}");
            //Console.WriteLine($"Part 2: {repository.Answer2()}");
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IBootCode, BootCode>();
            return container;
        }
    }
}