using System;
using Tools;
using Unity;

namespace TobogganTrajectory
{
    class Program
    {
        static void Main()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();

            var map = new Map(container.Resolve<IPuzzleInput>()
                .GetPuzzleInputAsArray("https://adventofcode.com/2020/day/3/input"));

            var treeCounter = new TreeCounter(map);

            Console.WriteLine($"Part 1: {treeCounter.Run(3,1)}");

            long product = 1;
            product *= treeCounter.Run(1, 1);
            product *= treeCounter.Run(3, 1);
            product *= treeCounter.Run(5, 1);
            product *= treeCounter.Run(7, 1);
            product *= treeCounter.Run(1, 2);

            Console.WriteLine($"Part 2: {product}");
        }
    }
}
