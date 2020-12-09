using System;
using EncodingError;
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

            var decoder = container.Resolve<IXmasDecoder>();

            Console.WriteLine($"Part 1: {decoder.FindFirstInvalidNumber()}");
            Console.WriteLine($"Part 2: {decoder.FindEncryptionWeakness()}");
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IXmasDecoder, XmasDecoder>();
            return container;
        }
    }
}