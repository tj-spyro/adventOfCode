using Intcode.Memory;
// ReSharper disable PossibleInvalidOperationException

namespace ThrusterAmplification
{
    public class Amplifier
    {
        private Intcode.Intcode _intcodeComputer;
        private readonly IMemory _program;
        private readonly int _phaseSetting;

        public Amplifier OutputAmplifier;

        public Amplifier(IMemory program, int phaseSetting)
        {
            _program = program;
            _phaseSetting = phaseSetting;
            Initialise();
        }

        public bool Halted => _intcodeComputer.Halted;

        public int Output => _intcodeComputer.Output().Value;

        private void Initialise()
        {
            if (_intcodeComputer != null)
            {
                return;
            }
            
            _intcodeComputer = new Intcode.Intcode(_program);
            _intcodeComputer.AddToInputQueue(_phaseSetting);
        }

        public int Run(int input)
        {
            Initialise();
            _intcodeComputer.AddToInputQueue(input);
            _intcodeComputer.ProcessInstructions();

            return _intcodeComputer.Output().Value;
        }

        public void RunToOutput()
        {
            Initialise();
            _intcodeComputer.ProcessInstructionsToOutput();

            OutputAmplifier.ReceiveInput(_intcodeComputer.Output().Value);
        }

        public void ReceiveInput(int input)
        {
            _intcodeComputer.AddToInputQueue(input);
        }
    }
}