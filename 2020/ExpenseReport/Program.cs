using System;
using Tools;
using Unity;

namespace ExpenseReport
{
    class Program
    {
        static void Main()
        {
            var container = BuildUnityContainer();

            var reportAnalyser = container.Resolve<IReportAnalyser>();

            Console.WriteLine($"Part 1: {ReportAnalyser.MultiplyReportValues(reportAnalyser.FindTwoValuesTotalling(2020))}");
            Console.WriteLine($"Part 2: {ReportAnalyser.MultiplyReportValues(reportAnalyser.FindThreeValuesTotalling(2020))}");
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IReportAnalyser, ReportAnalyser>();
            return container;
        }
    }
}