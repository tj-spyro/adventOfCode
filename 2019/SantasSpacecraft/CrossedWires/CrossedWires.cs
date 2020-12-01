using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossedWires
{
    public class CrossedWires
    {
        public static int GetManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        private (int x, int y) GetIntersection(string input1, string input2)
        {
            var path1 = GetPath(input1);
            var path2 = GetPath(input2);

            var intersections = GetIntersections(path1, path2);

            var minimumDistance = intersections.Min(i => GetManhattanDistance(0, i.Key.x, 0, i.Key.y));
            return intersections.First(i => GetManhattanDistance(0, i.Key.x, 0, i.Key.y) == minimumDistance).Key;
        }

        public int GetDistanceFromCentralPort(string input1, string input2)
        {
            var intersection = GetIntersection(input1, input2);

            return GetManhattanDistance(0, intersection.x, 0, intersection.y);
        }

        public int GetQuickestRoute(string input1, string input2)
        {
            var path1 = GetPath(input1);
            var path2 = GetPath(input2);

            var intersections = GetIntersections(path1, path2);

            var combinedPathLength = intersections.ToDictionary(i => i.Key, i => i.Value + path2[i.Key]);

            return combinedPathLength.Min(i => i.Value);
        }

        private static Dictionary<(int x, int y), int> GetIntersections(Dictionary<(int x, int y), int> dict1, Dictionary<(int x, int y), int> dict2)
        {
            return dict1.Keys.Intersect(dict2.Keys).ToDictionary(i => i, i => dict1[i]);
        }

        private Dictionary<(int x, int y), int> GetPath(string input)
        {
            var path = new Dictionary<(int x, int y), int>();

            var commands = GetCommands(input);

            int x = 0, y = 0, pathLength = 0;
            foreach(var command in commands)
            {
                var (dX, dY) = GetDirection(command);
                var distance = int.Parse(command[1..]);
                for (int i = 0; i < distance; i++)
                {
                    x += dX;
                    y += dY;

                    path.TryAdd((x, y), ++pathLength);
                }
            }

            return path;
        }

        private string[] GetCommands(string input)
        {
            return input.Split(",");
        }

        private static (int dX, int dY) GetDirection(string input)
        {
            var dir = input[0].ToString();

            return dir switch
            {
                "U" => (0, 1),
                "D" => (0, -1),
                "L" => (1, 0),
                "R" => (-1, 0),
                _ => throw new ApplicationException($"Unknown direction '{dir}'"),
            };
        }
    }
}
