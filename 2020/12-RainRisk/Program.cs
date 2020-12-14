using System;
using Tools;
using Unity;
// ReSharper disable CheckNamespace

namespace RainRisk
{
    class Program
    {
        static void Main()
        {
            var container = BuildUnityContainer();

            var navigator = container.Resolve<INavigator>();
            navigator.ExecuteActions();
            Console.WriteLine($"Part 1: {navigator.GetManhattanDistance()}");

            var waypointNavigator = container.Resolve<INavigator>(nameof(WaypointNavigator));
            waypointNavigator.ExecuteActions();
            Console.WriteLine($"Part 2: {waypointNavigator.GetManhattanDistance()}");
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<INavigator, Navigator>();
            container.RegisterType<INavigator, WaypointNavigator>(nameof(WaypointNavigator));
            return container;
        }
    }
}
