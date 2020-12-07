using System;
using Tools;
using Unity;

namespace BinaryBoarding
{
    class Program
    {
        static void Main()
        {
            var container = BuildUnityContainer();

            var repository = container.Resolve<IBoardingPassRepository>();

            Console.WriteLine($"Part 1: {repository.MaxSeatId}");
            Console.WriteLine($"Part 2: {repository.FindSeat()}");
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IBoardingPassRepository, BoardingPassRepository>();
            return container;
        }
    }
}
