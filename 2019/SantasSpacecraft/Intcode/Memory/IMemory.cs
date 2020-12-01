namespace Intcode.Memory
{
    public interface IMemory
    {
        int[] GetState();
        int GetValue(int address);
        void SetValue(int address, int newValue);
        void ResetState();
    }
}