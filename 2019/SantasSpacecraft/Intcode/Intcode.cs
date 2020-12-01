using System;
using System.Collections.Generic;
using System.Linq;
using Intcode.Memory;

namespace Intcode
{
    public class Intcode
    {
        public Intcode(IMemory memory, int input)
        {
            _memory = memory;
            AddToInputQueue(input);
        }

        public Intcode(IMemory memory)
        {
            _memory = memory;
        }

        private int GetInput()
        { 
            return _inputQueue.Dequeue();
        }

    private readonly Queue<int> _inputQueue = new Queue<int>();

        public void AddToInputQueue(int input)
        {
            _inputQueue.Enqueue(input);
            _waiting = false;
        }

        private int _instructionPointer;

        private int NextPointer()
        {
            return ++_instructionPointer;
        }

        private readonly List<int> _output = new List<int>();

        public int? Output()
        {
            return _output.Count > 0 ? _output.Last() : (int?) null;
        }

        private readonly IMemory _memory;

        private bool _sentOutput;
        private bool _waiting;

        public bool Halted;

        public void ProcessInstructions()
        {
            while (HandleInstruction())
            {
            }
        }

        public void ProcessInstructionsToOutput()
        {
            _sentOutput = false;
            while (!_waiting && !_sentOutput && HandleInstruction())
            {
            }
        }

        public int FindNounVerb(int targetOutput)
        {
            for (var i = 0; i < 100; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    _memory.SetValue(1, i);
                    _memory.SetValue(2, j);
                    ProcessInstructions();
                    var result = _memory.GetState()[0];
                    if (result == targetOutput)
                    {
                        return (100 * i) + j;
                    }
                    _memory.ResetState();
                }
            }
            return 0;
        }

        private bool HandleInstruction()
        {
            var (oppCode, modes) = GetInstruction();

            if (oppCode == OppCode.Input)
            {
                if (_inputQueue.Count > 0)
                {
                    
                    _memory.SetValue(_memory.GetValue(NextPointer()), GetInput());
                }
                else
                {
                    _waiting = true;
                }
            }
            else if (oppCode == OppCode.Output)
            {
                _output.Add(GetValue(modes[0]));
                _sentOutput = true;
            }
            else if (oppCode == OppCode.Terminate)
            {
                Halted = true;
                return false;
            }
            else
            {
                var value1 = GetValue(modes[0]);
                var value2 = GetValue(modes[1]);

                switch (oppCode)
                {
                    case OppCode.Add:
                        _memory.SetValue(GetValue(Mode.Immediate), value1 + value2);
                        break;
                    case OppCode.Multiply:
                        _memory.SetValue(GetValue(Mode.Immediate), value1 * value2);
                        break;
                    case OppCode.JumpTrue:
                        if(value1 != 0)
                        {
                            _instructionPointer = value2; 
                            return true; 
                        }
                        break;
                    case OppCode.JumpFalse:
                        if(value1 == 0)
                        {
                            _instructionPointer = value2; 
                            return true; 
                        }
                        break;
                    case OppCode.LessThan:
                        _memory.SetValue(GetValue(Mode.Immediate), value1 < value2 ? 1 : 0);
                        break;
                    case OppCode.Equals:
                        _memory.SetValue(GetValue(Mode.Immediate), value1 == value2 ? 1 : 0);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Unknown OppCode '{oppCode}'!");
                }
            }

            // ReSharper disable once AssignmentIsFullyDiscarded
            _ = NextPointer();

            return true;
        }

        public (OppCode oppCode, Mode[] modes) GetInstruction()
        {
            var instruction = _memory.GetValue(_instructionPointer);

            return (GetOppCode(instruction), GetParameterModes(instruction));
        }

        public static OppCode GetOppCode(int instruction)
        {
            return (OppCode) (instruction % 100);
        }

        public static Mode[] GetParameterModes(int instruction)
        {
            return instruction.ToString("D5").Remove(3).Reverse()
                .Select(c => Enum.Parse<Mode>(c.ToString()))
                .ToArray();
        }

        private int GetValue(Mode mode)
        {
            return mode == Mode.Position
                ? _memory.GetValue(_memory.GetValue(NextPointer()))
                : _memory.GetValue(NextPointer());
        }
    }
}
