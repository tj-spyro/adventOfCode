using System;
using System.Linq;

namespace Intcode
{
    public class Intcode
    {
        public Intcode(string str)
        {
            State = ConvertStringToState(str);
        }

        public int[] State;

        public void ProcessState()
        {
            var i = 0;
            var continueProcessing = true;
            while (continueProcessing)
            {
                continueProcessing = HandleSection(i);
                i += 4;
            }
        }

        public int[] ConvertStringToState(string str)
        {
            return str.Split(",").Select(s => int.Parse(s.Trim())).ToArray();
        }

        public void ResetState()
        {
            State[1] = 12;
            State[2] = 2;
        }

        public bool HandleSection(int startPosition)
        {
            var oppCode = (OppCode)State[startPosition];

            if (oppCode == OppCode.Terminate)
            {
                return false;
            }

            var inputPosition1 = State[startPosition + 1];
            var inputPosition2 = State[startPosition + 2];
            var outputPosition = State[startPosition + 3];

            var inputValue1 = State[inputPosition1];
            var inputValue2 = State[inputPosition2];

            int result;
            switch (oppCode)
            {
                case OppCode.Add:
                    result = Add(inputValue1, inputValue2);
                    break;
                case OppCode.Multiply:
                    result = Multiply(inputValue1, inputValue2);
                    break;
                case OppCode.Terminate:
                    return false;
                default:
                    throw new ApplicationException();
            }

            State[outputPosition] = result;

            return true;
        }

        public int Add(int input1, int input2)
        {
            return input1 + input2;
        }

        public int Multiply(int input1, int input2)
        {
            return input1 * input2;
        }
    }

    public enum OppCode
    {
        Add = 1,
        Multiply,
        Terminate = 99
    }
}
