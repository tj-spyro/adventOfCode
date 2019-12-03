using System;
using System.Linq;

namespace Intcode
{
    public class Intcode
    {
        public Intcode(string str)
        {
            _memory = SetInitialState(str);
        }

        private readonly int[] _memory;

        public int[] GetState()
        {
            return _memory;
        }

        public void ProcessInstructions()
        {
            var i = 0;
            var continueProcessing = true;
            while (continueProcessing)
            {
                continueProcessing = HandleInstruction(i, out int j);
                i = j;
            }
        }

        public int FindNounVerb(int targetOutput)
        {
            var initialState = (int[])GetState().Clone();

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    SetValue(1, i);
                    SetValue(2, j);
                    ProcessInstructions();
                    var result = GetState()[0];
                    if (result == targetOutput)
                    {
                        return (100 * i) + j;
                    }
                    ResetState(initialState);
                }
            }
            return 0;
        }

        public int[] SetInitialState(string str)
        {
            return str.Split(",").Select(s => int.Parse(s.Trim())).ToArray();
        }

        public void ResetState()
        {
            SetValue(1, 12);
            SetValue(2, 2);
        }

        public void ResetState(int[] initialState)
        {
            for (int i = 0; i < initialState.Length; i++)
            {
                SetValue(i, initialState[i]);
            }
        }

        public bool HandleInstruction(int instructionPointer, out int nextInstructionPoninter)
        {
            var oppCode = (OppCode)_memory[instructionPointer];

            switch (oppCode)
            {
                case OppCode.Terminate:
                    nextInstructionPoninter = instructionPointer + 1;
                    return false;
                case OppCode.Add:
                    Add(instructionPointer);
                    nextInstructionPoninter = instructionPointer + 4;
                    break;
                case OppCode.Multiply:
                    Multiply(instructionPointer);
                    nextInstructionPoninter = instructionPointer + 4;
                    break;
                default:
                    throw new ApplicationException($"Unknown OppCode {oppCode}");
            }

            return true;
        }

        public void Add(int instructionPointer)
        {
            var value1Address = GetValue(instructionPointer + 1);
            var value2Address = GetValue(instructionPointer + 2);
            var value3Address = GetValue(instructionPointer + 3);

            SetValue(value3Address, GetValue(value1Address) + GetValue(value2Address));
        }

        public void Multiply(int instructionPointer)
        {
            var value1Address = GetValue(instructionPointer + 1);
            var value2Address = GetValue(instructionPointer + 2);
            var value3Address = GetValue(instructionPointer + 3);

            SetValue(value3Address, GetValue(value1Address) * GetValue(value2Address));
        }

        private int GetValue(int address)
        {
            return _memory[address];
        }

        private void SetValue(int address, int newValue)
        {
            _memory[address] = newValue;
        }
    }

    public enum OppCode
    {
        Add = 1,
        Multiply,
        Terminate = 99
    }
}
