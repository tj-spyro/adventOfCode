using System;
using System.Collections.Generic;
using Tools;
// ReSharper disable CheckNamespace

namespace HandheldHalting
{
    public class BootCode : IBootCode
    {
        private readonly IPuzzleInput _puzzleInput;
        private const string PuzzleInputUrl = "https://adventofcode.com/2020/day/8/input";

        private string[] _rawData;
        private string[] RawData => _rawData ??= _puzzleInput.GetPuzzleInputAsArray(PuzzleInputUrl);

        public BootCode(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }

        public int Answer1()
        {
            var accumulator = 0;
            var position = 0;

            var visitedPositions = new Queue<int>();

            while (!visitedPositions.Contains(position) && position < RawData.Length)
            {
                var instruction = RawData[position];
                var parts = instruction.Split(' ');
                var operation = parts[0];
                var argument = int.Parse(parts[1]);

                var newPosition = position;

                switch (operation)
                {
                    case "acc":
                        accumulator += argument;
                        newPosition++;
                        break;
                    case "jmp":
                        newPosition += argument;
                        break;
                    case "nop":
                        newPosition++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(operation), operation, "Invalid operation code!");
                }

                visitedPositions.Enqueue(position);
                position = newPosition;
            }

            return accumulator;
        }
    }
}