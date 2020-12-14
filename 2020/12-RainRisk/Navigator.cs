using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Tools;

// ReSharper disable CheckNamespace

namespace RainRisk
{
    public class Navigator : INavigator
    {
        private readonly IPuzzleInput _puzzleInput;
        private const string PuzzleInputUrl = "https://adventofcode.com/2020/day/12/input";

        private List<string> _rawData;
        private List<string> RawData => _rawData ??= _puzzleInput.GetPuzzleInputAsArray(PuzzleInputUrl).ToList();

        public Navigator(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
            _heading = 0;
            _currentPosition = Point.Empty;
        }

        private int _heading;
        public Heading Heading => (Heading)_heading;

        private Point _currentPosition;
        public Point CurrentPosition => _currentPosition;

        public void ExecuteActions() => RawData.ForEach(ExecuteAction);

        public int GetManhattanDistance() => GetManhattanDistance(new Point(0, 0), _currentPosition);

        private static int GetManhattanDistance(Point point1, Point point2)
        {
            return Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y);
        }

        public void ExecuteAction(string input)
        {
            var action = input[0];
            var value = int.Parse(input[1..]);

            switch (action)
            {
                case 'N':
                    _currentPosition.Offset(0,value);
                    break;
                case 'S':
                    _currentPosition.Offset(0, value * -1);
                    break;
                case 'E':
                    _currentPosition.Offset(value, 0);
                    break;
                case 'W':
                    _currentPosition.Offset(value * -1, 0);
                    break;
                case 'L':
                    SetHeading(value * -1);
                    break;
                case 'R':
                    SetHeading(value);
                    break;
                case 'F':
                    MoveForward(value);
                    break;
                default:
                    throw new ApplicationException("Unknown action!");
            }
        }

        private void SetHeading(int value)
        {
            var newHeading = _heading + value;

            _heading = newHeading < 0 ? newHeading + 360 : newHeading >= 360 ? newHeading - 360 : newHeading;
        }

        private void MoveForward(int value)
        {
            var action = Heading switch
            {
                Heading.East => "E",
                Heading.South => "S",
                Heading.West => "W",
                Heading.North => "N",
                _ => throw new ArgumentOutOfRangeException()
            };

            ExecuteAction($"{action}{value}");
        }
    }
}