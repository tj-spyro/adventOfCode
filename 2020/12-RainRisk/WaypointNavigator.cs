using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Tools;

// ReSharper disable CheckNamespace

namespace RainRisk
{
    public class WaypointNavigator : INavigator
    {
        private readonly IPuzzleInput _puzzleInput;
        private const string PuzzleInputUrl = "https://adventofcode.com/2020/day/12/input";

        private List<string> _rawData;
        private List<string> RawData => _rawData ??= _puzzleInput.GetPuzzleInputAsArray(PuzzleInputUrl).ToList();

        public WaypointNavigator(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
            _heading = 0;
            _currentPosition = Point.Empty;
            _waypoint = new Point(10, 1);
        }

        private int _heading;
        public Heading Heading => (Heading)_heading;

        private Point _currentPosition;
        public Point CurrentPosition => _currentPosition;

        private Point _waypoint;
        public Point Waypoint => _waypoint;

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
                    _waypoint.Offset(0,value);
                    break;
                case 'S':
                    _waypoint.Offset(0, value * -1);
                    break;
                case 'E':
                    _waypoint.Offset(value, 0);
                    break;
                case 'W':
                    _waypoint.Offset(value * -1, 0);
                    break;
                case 'L':
                    RotateWaypointCounterClockwise(value );
                    break;
                case 'R':
                    RotateWaypointClockwise(value);
                    break;
                case 'F':
                    MoveForward(value);
                    break;
                default:
                    throw new ApplicationException("Unknown action!");
            }
        }

        private void RotateWaypointClockwise(int angle)
        {
            var times = angle / 90;

            for (var i = 0; i < times; i++)
            {
                _waypoint = new Point(_waypoint.Y, _waypoint.X * -1);
            }
        }

        private void RotateWaypointCounterClockwise(int angle)
        {
            var times = angle / 90;

            for (var i = 0; i < times; i++)
            {
                _waypoint = new Point(_waypoint.Y * -1, _waypoint.X);
            }
        }

        private void MoveForward(int numberOfTimes)
        {
            for (var i = 0; i < numberOfTimes; i++)
            {
                _currentPosition.Offset(_waypoint);
            }
        }
    }
}