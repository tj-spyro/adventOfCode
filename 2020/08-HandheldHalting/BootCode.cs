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
            var instructions = CopyInstructions();

            return Execute(instructions).accumulator;
        }

        public int Answer2()
        {
            for (var i = 0; i < RawData.Length; i++)
            {
                var instructions = CopyInstructions();

                var instruction = instructions[i];
                var parts = instruction.Split(' ');
                instruction = parts[0] switch
                {
                    "jmp" => instruction.Replace("jmp", "nop"),
                    "nop" => instruction.Replace("nop", "jmp"),
                    _ => instruction
                };
                instructions[i] = instruction;

                var (accumulator, position) = Execute(instructions);
                if (position == instructions.Length)
                {
                    return accumulator;
                }
            }

            throw new ApplicationException("Not found!");
        }

        private string[] CopyInstructions()
        {
            var instructions = new string[RawData.Length];
            Array.Copy(RawData, instructions, RawData.Length);
            return instructions;
        }

        private (int accumulator, int position) Execute(string[] instructions)
        {
            var accumulator = 0;
            var position = 0;

            var visitedPositions = new Queue<int>();

            while (!visitedPositions.Contains(position) && position < instructions.Length)
            {
                var instruction = instructions[position];
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

            return (accumulator, position);
        }
    }
}