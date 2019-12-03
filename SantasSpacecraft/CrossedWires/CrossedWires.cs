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

            var intersections = path1.Keys.Intersect(path2.Keys).ToDictionary(i => i, i => path1[i]);

            var minimumDistance = intersections.Min(i => i.Value);
            return intersections.First(i => i.Value == minimumDistance).Key;
        }

        public int GetDistanceFromCentralPort(string input1, string input2)
        {
            var intersection = GetIntersection(input1, input2);

            return GetManhattanDistance(0, intersection.x, 0, intersection.y);
        }

        public Dictionary<(int x, int y), int> GetPath(string input)
        {
            var path = new Dictionary<(int x, int y), int>();

            var commands = GetCommands(input);

            int x = 0, y = 0;
            foreach(var command in commands)
            {
                var (dX, dY) = GetDirection(command);
                var distance = int.Parse(command[1..]);
                for (int i = 0; i < distance; i++)
                {
                    x += dX;
                    y += dY;

                    path.TryAdd((x, y), GetManhattanDistance(0, x, 0, y));
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
