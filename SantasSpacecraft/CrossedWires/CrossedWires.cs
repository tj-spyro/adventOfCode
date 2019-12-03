using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossedWires
{
    public class CrossedWires
    {
        public int GetManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        public (int x, int y) GetIntersection(string input1, string input2)
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

        public Dictionary<(int x, int y), int> GetIntersections(Dictionary<(int x, int y), int> dict1, Dictionary<(int x, int y), int> dict2)
        {
            return dict1.Keys.Intersect(dict2.Keys).ToDictionary(i => i, i => dict1[i]);
        }

        public Dictionary<(int x, int y), int> GetPath(string input)
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

        public string[] GetCommands(string input)
        {
            return input.Split(",");
        }

        public (int dX, int dY) GetDirection(string input)
        {
            var dir = input[0].ToString();

            switch (dir)
            {
                case "U":
                    return (0, 1);
                case "D":
                    return (0, -1);
                case "L":
                    return (1, 0);
                case "R":
                    return (-1, 0);
                default:
                    throw new ApplicationException($"Unknown direction '{dir}'");
            }
        }
    }
}
