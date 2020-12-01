using System.Linq;

namespace Intcode.Memory
{
    public class IntcodeMemory : IMemory
    {
        public IntcodeMemory(string str)
        {
            _initialState = str;
        }

        private readonly string _initialState;

        private int[] _memory;

        private int[] Memory
        {
            get
            {
                if (_memory == null)
                {
                    SetInitialState();
                }

                return _memory;
            }
        }

        public int[] GetState()
        {
            return Memory;
        }

        public int GetValue(int address)
        {
            return Memory[address];
        }

        public void SetValue(int address, int newValue)
        {
            Memory[address] = newValue;
        }

        public void ResetState()
        {
            SetInitialState();
        }

        private void SetInitialState()
        {
            _memory = _initialState.Split(",").Select(s => int.Parse(s.Trim())).ToArray();
        }
    }
}